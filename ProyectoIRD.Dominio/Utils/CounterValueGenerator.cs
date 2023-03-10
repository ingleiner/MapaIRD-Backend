using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace ProyectoIRD.Dominio.Utils
{
    /// <summary>
    /// Procedimiento para configurar el campo Orden y darle un valor incremental
    /// de 1 en 1
    /// </summary>
    public class CounterValueGenerator : ValueGenerator<int>
    {
        private int _currentValue;

        public CounterValueGenerator()
        {
            _currentValue = 0;
        }

        public override bool GeneratesTemporaryValues => false;

        public override int Next(EntityEntry entry)
        {
            return ++_currentValue;
        }
    }
}



