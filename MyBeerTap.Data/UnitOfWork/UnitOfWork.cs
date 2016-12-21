using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using MyBeerTap.Data.Models;
using MyBeerTap.Data.GenericRepository;

namespace MyBeerTap.Data.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...

        private BeerTapDBContext _context = null;
        private GenericRepository<OfficeEntity> _officeRepository;
        private GenericRepository<TapEntity> _tapRepository;
        private GenericRepository<KegEntity> _kegRepository;
        private GenericRepository<GlassEntity> _glassRepository;
        #endregion

        public UnitOfWork()
        {
            _context = new BeerTapDBContext();
        }

        #region Public Repository Creation properties...

        /// <summary>
        /// Get/Set Property for office repository.
        /// </summary>
        public GenericRepository<OfficeEntity> OfficeRepository
        {
            get
            {
                if (this._officeRepository == null)
                    this._officeRepository = new GenericRepository<OfficeEntity>(_context);
                return _officeRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for tap repository.
        /// </summary>
        public GenericRepository<TapEntity> TapRepository
        {
            get
            {
                if (this._tapRepository == null)
                    this._tapRepository = new GenericRepository<TapEntity>(_context);
                return _tapRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for keg repository.
        /// </summary>
        public GenericRepository<KegEntity> KegRepository
        {
            get
            {
                if (this._kegRepository == null)
                    this._kegRepository = new GenericRepository<KegEntity>(_context);
                return _kegRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for Glass repository.
        /// </summary>
        public GenericRepository<GlassEntity> GlassRepository
        {
            get
            {
                if (this._glassRepository == null)
                    this._glassRepository = new GenericRepository<GlassEntity>(_context);
                return _glassRepository;
            }
        }
        #endregion


        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
