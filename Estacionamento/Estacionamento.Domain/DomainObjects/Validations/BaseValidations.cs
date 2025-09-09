using System.Text.RegularExpressions;

namespace Estacionamento.Domain.DomainObjects.Validations
{
    public class BaseValidations
    {
        public static void ValidarEhIgual(object obj1, object obj2, string message)
        {
            if(!obj1.Equals(obj2))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidarEhDiferente(object obj1, object obj2, string message)
        {
            if (obj1.Equals(obj2))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidarCaracteres(string value, int max, string message)
        {
            var valueLenth = value.Trim().Length;
            if (valueLenth > max)
            {
                throw new DomainException(message);
            }
        }


        public static void ValidarCaracteres(string value, int min, int max, string message)
        {
            var valueLenth = value.Trim().Length;
            if (valueLenth > max || valueLenth < min)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidarExpressao(string pattern, string value, string message)
        {
            var regex = new Regex(pattern);
            if (!regex.IsMatch(value))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidarSeNulo(object value, string message)
        {
            if (value is null)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidarSeVazio(string value, string message)
        {
            if (value is null || value.Trim().Length == 0)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidarMinimoVaximo(decimal value, decimal min, decimal max, string message)
        {
            if (value < min || value > max)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidarMinimoVaximo(double value, double min, double max, string message)
        {
            if (value < min || value > max)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidarMinimoVaximo(float value, float min, float max, string message)
        {
            if (value < min || value > max)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidarMinimoVaximo(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidarSeMenorIgualMinimo(decimal value, decimal min, string message)
        {
            if (value <= min)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidarSeMenorIgualMinimo(double value, double min, string message)
        {
            if (value <= min)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidarSeMenorIgualMinimo(float value, float min, string message)
        {
            if (value <= min)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidarSeMenorIgualMinimo(int value, int min, string message)
        {
            if (value <= min)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidarSeVerdadeiro(bool value, string message)
        {
            if (!value)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidarSeFalso(bool value, string message)
        {
            if (value)
            {
                throw new DomainException(message);
            }
        }
    }
}
