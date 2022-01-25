using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ЗаданиеWpf6
{
    class WatherControl : DependencyObject  // приложение класса моделирующего погодную сводку
    {
        private static readonly DependencyProperty TemperatureProperty; //  температура в диапозоне от -50 до +50
        
        private string wind; // направление ветра строка

        private int windVelosity; // скорость ветра целое число

        private int wheathErtype; // наличие осадков
        enum WhewheathErtype      // перечисление осадков
        {
            synny = 0,           //  солнечная погода
            cloudy = 1,          // облачная погода
            rainy = 2,           // дождь
            snowly = 3           // снег
        }

        public int Temperature // свойство определения температуры
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        public string Wind // свойство определения направления ветра
        {
            get => wind;
            set => wind = value;
        }

        public int WindVelosity // свойство определения скорости ветра
        {
            get => windVelosity;
            set => windVelosity = value;
        }

        public int WheathErtype // свойство определения наличия осадков
        {
            get => wheathErtype;
            set => wheathErtype = value;
        }

        public WatherControl (int temperature, string wind, int windVelocity, int wheathErtype) // ??? раскрыть 
        {
            this.Temperature = temperature;
            this.Wind = wind;
            this.WindVelosity = windVelosity;
            this.WheathErtype = wheathErtype;
        }

        static WatherControl() // свойство завсимостей
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.Journal,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
        }

        private static bool ValidateTemperature(object value) // метод определения температуры
        {
            int t = (int)value;
            if (t >= -50 && t <= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t >= -50 && t <= 50)
            {
                return t;
            }
            else
            {
                if (t < -50)
                {
                    return -50;
                }
                return 50;
            }
        }

        public string Print() // метод печати
        {
            return $"{ Temperature} {Wind} {WindVelosity} {WheathErtype}";
        }
    }


    
}
