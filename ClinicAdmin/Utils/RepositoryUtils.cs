using AutoMapper.Internal;
using ClinicAdmin.Entities;
using Npgsql;

namespace ClinicAdmin.Utils
{
    public static class RepositoryUtils
    {
        public static List<NpgsqlParameter> ParametersGenerator<T>(T obj)
        {
            var excludedTypes = new HashSet<Type>
            {
                typeof(Patient), typeof(Employee), typeof(Service), typeof(Appointment),
                typeof(AppointmentService), typeof(Prescription), typeof(Medication), typeof(Diagnosis)
            };
            var type = typeof(T);
            List<NpgsqlParameter> parameters = [];
            foreach (var Prop in type.GetProperties())
            {
                if (!(Prop.PropertyType.IsGenericType) && !(excludedTypes.Contains(Prop.PropertyType)))
                    parameters.Add(new NpgsqlParameter($"{Prop.Name}", Prop.GetValue(obj)));
            }
            return parameters;
        }

        public static void CopyObject<T>(T source, T target)
        {
            var type = typeof(T);
            foreach (var sourceProperty in type.GetProperties())
            {
                var targetProperty = type.GetProperty(sourceProperty.Name);
                targetProperty?.SetValue(target, sourceProperty.GetValue(source, null), null);
            }
            foreach (var sourceField in type.GetFields())
            {
                var targetField = type.GetField(sourceField.Name);
                targetField?.SetValue(target, sourceField.GetValue(source));
            }
        }

    }
}
