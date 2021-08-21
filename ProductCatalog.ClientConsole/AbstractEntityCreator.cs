using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductCatalog.ClientConsole
{
    public abstract class AbstractEntityCreator<T>
    {
        protected T _entity;
        protected string _serializedEntity;

        public event Action OnSuccess;
        public event Action OnFailure;

        protected abstract bool CreateEntity();
        protected virtual bool Serialize()
        {
            _serializedEntity = JsonSerializer.Serialize(_entity);
            return true;
        }
        protected abstract Task<bool> SaveAsync();

        public T Entity
        {
            get { return _entity; }
        }

        public virtual async Task<bool> CreateAsync()
        {
            if (!CreateEntity())
            {
                OnFailure.Invoke();
                return false;
            }
            if(!Serialize())
            {
                OnFailure.Invoke();
                return false;
            }
            if (!await SaveAsync())
            {
                return false;
            }
            if (OnSuccess != null)
            {
                OnSuccess.Invoke();
            }
            return true;
        }
        private void InvokeFailure()
        {
            if (OnFailure != null)
            {
                OnFailure.Invoke();
            }
        }
    }
}
