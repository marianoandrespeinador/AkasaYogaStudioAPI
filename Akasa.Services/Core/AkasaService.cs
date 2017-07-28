using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Akasa.Data;
using Akasa.Dto.Core;
using Akasa.Model.Core;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Akasa.Services.Core
{
    public abstract class AkasaService<TDataEntity, TGetDto, TInsertDto,TUpdateDto> : IAkasaService<TGetDto, TInsertDto, TUpdateDto>
        where TDataEntity : FiniteDataEntity
        where TGetDto : FiniteDataEntityDto
        where TInsertDto : FiniteDataEntityDto
        where TUpdateDto : FiniteDataEntityDto
    {
        private Dictionary<string, HashSet<string>> _selectQueryDependencyDictionary;
        protected readonly IMapper _mapperService;
        protected readonly AkasaDBContext _context;
        protected readonly DbSet<TDataEntity> _thisDbSet;

        public AkasaService(AkasaDBContext context
            , IMapper mapperServiceToSet)
        {
            _mapperService = mapperServiceToSet;
            _context = context;
            _thisDbSet = context.Set<TDataEntity>();
        }

        protected virtual async Task<TDataEntity> GetRaw(int id)
            => await _thisDbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        protected virtual async Task<TDataEntity> GetRawWithTrack(int id)
            => await _thisDbSet.FirstOrDefaultAsync(e => e.Id == id);

        public virtual async Task<List<TGetDto>> Get()
        {
            var rawList = await _thisDbSet
                .AsNoTracking()
                .WhereIsValid()
                .ToListAsync();

            return _mapperService.Map<List<TGetDto>>(rawList);
        }

        public virtual async Task<TGetDto> Get(int id)
        {
            var bank = await GetRaw(id);

            return _mapperService.Map<TGetDto>(bank);
        }

        private async Task ExecuteExistsMethod(Expression<Func<DbSet<TDataEntity>, Task<bool>>> existsMethodFromRepo)
        {
            var existsCompiled = existsMethodFromRepo.Compile();
            var existsInvoked = existsCompiled.Invoke(_thisDbSet);
            var exists = await existsInvoked;

            if (exists)
            {
                throw new Exception(Messages.DBExists);
            }
        }

        public virtual async Task<TDataEntity> UpdateUncommited(int id
            , TUpdateDto dtoUpdate
            , Expression<Func<DbSet<TDataEntity>, Task<bool>>> existsMethodFromRepo = null)
        {
            var entity = await GetRawWithTrack(id);

            entity = _mapperService.Map(dtoUpdate, entity);

            if (existsMethodFromRepo != null)
            {
                await ExecuteExistsMethod(existsMethodFromRepo);
            }

            var dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;

            return entity;
        }

        public virtual async Task Update(int id
            , TUpdateDto dtoUpdate
            , Expression<Func<DbSet<TDataEntity>, Task<bool>>> existsMethodFromRepo)
        {
            await UpdateUncommited(id, dtoUpdate, existsMethodFromRepo);

            await _context.SaveChangesAsync();
        }

        public virtual async Task Update(int id, TUpdateDto dtoUpdate)
        {
            await UpdateUncommited(id, dtoUpdate, null);

            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(int id)
        {
            var entity = await GetRawWithTrack(id);
            
            entity.EndDate = DateTime.Now;

            var dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public virtual async Task<TDataEntity> InsertUncommited(TDataEntity newItem
            , Expression<Func<DbSet<TDataEntity>, Task<bool>>> existsMethodFromRepo)
        {
            await ExecuteExistsMethod(existsMethodFromRepo);

            _thisDbSet.Add(newItem);

            return newItem;
        }

        public virtual async Task<TDataEntity> InsertUncommited(TInsertDto dtoToInsert
            , Expression<Func<DbSet<TDataEntity>, Task<bool>>> existsMethodFromRepo
            , params Action<TDataEntity>[] dataOptions)
        {
            var newItem = _mapperService.Map<TDataEntity>(dtoToInsert);

            dataOptions?.ToList().ForEach(p => p(newItem));

            if (existsMethodFromRepo != null)
            {
                await ExecuteExistsMethod(existsMethodFromRepo);
            }

            _thisDbSet.Add(newItem);

            return newItem;
        }

        public virtual async Task<TGetDto> Insert(TInsertDto dtoToInsert
            , Expression<Func<DbSet<TDataEntity>, Task<bool>>> existsMethodFromRepo)
        {
            var newBank = await InsertUncommited(dtoToInsert, existsMethodFromRepo);

            await _context.SaveChangesAsync();

            return await Get(newBank.Id);
        }

        public virtual async Task<TGetDto> Insert(TInsertDto dtoToInsert
            , Expression<Func<DbSet<TDataEntity>, Task<bool>>> existsMethodFromRepo
            , params Action<TDataEntity>[] dataOptions)
        {
            var newBank = await InsertUncommited(dtoToInsert, existsMethodFromRepo, dataOptions);

            await _context.SaveChangesAsync();

            return await Get(newBank.Id);
        }

        public virtual async Task<TGetDto> Insert(TInsertDto dtoToInsert)
        {
            var newBank = await InsertUncommited(dtoToInsert, null);

            await _context.SaveChangesAsync();

            return await Get(newBank.Id);
        }

        protected virtual KeyValuePair<int, string> GetAsKeyValue(TDataEntity record)
        {
            if (!(record is FiniteDataEntityCatalog))
            {
                throw new NotImplementedException();
            }
            
            var recCatalog = record as FiniteDataEntityCatalog;
            return new KeyValuePair<int, string>(recCatalog.Id, recCatalog.Name);
        }

        public virtual async Task<List<KeyValuePair<int, string>>> GetDropDown()
        {
            var rightNow = DateTime.Now;

            var rawList = await _thisDbSet
                .AsNoTracking()
                .WhereIsValid()
                .Select(p => GetAsKeyValue(p))
                .ToListAsync();

            return rawList;
        }
    }
}
