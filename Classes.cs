using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJIoT_DBModel
{
    public class PropertyType
    {
        public int Id { get; set; }
        public DeviceType DeviceType { get; set; }
        public string Name { get; set; }
        public PropertyFormat Format { get; set; }
        public bool UIConfigurable { get; set; }
        public bool IsListenerProperty { get; set; }
        public bool IsSenderProperty { get; set; }
    }

    public class DeviceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DeviceType BaseDeviceType { get; set; }
        //public PropertyType SenderProperty { get; set; }
        //public PropertyType ListenerProperty { get; set; }
        public bool IsAbstract { get; set; }
        public bool OfflineMessagesEnabled { get; set; }
    }

    //DEPRECATED
    public class DeviceProperty
    {
        public int Id { get; set; }
        public Device Device { get; set; }
        public PropertyType PropertyType { get; set; }
        public string PropertyValue { get; set; }  //zawsze string, z PropertyType można odczytać jaki jest format właściwy

    }

    public class Device
    {
        public int Id { get; set; }
        public string IoTHubKey { get; set; }
        public DeviceType DeviceType { get; set; }
        //public ICollection<Device> ListenerDevices { get; set; }
        public User User { get; set; }
    }

    public class Connection
    {
        public int Id { get; set; }
        public Device SenderDevice { get; set; }
        public Device ListenerDevice { get; set; }
        public PropertyType SenderProperty { get; set; }
        public PropertyType ListenerProperty { get; set; }
        public ConnectionFilter Filter { get; set; }
        public string FilterValue { get; set; }
        public ConnectionCalculation Calculation { get; set; }
        public string CalculationValue { get; set; }
        public User User { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        //public ICollection<Device> Devices { get; set; }
    }

    public enum PropertyFormat : int
    {
        Boolean,  //przełącznik
        //OneByte,  //np. PWM, coś w rodzaju Int, bezpieczny zakres 0-255
        String,   //string - informuje, że: jest stringiem oraz, że dane urządzenie odbiera informacje "surowe", cyzli w tkaiej formie w jakiej zostało wysłane z nadawcy - dlatego, że każda propercja zapisuje dane jako string!
        Number  //zmiennoprzecinkowe
    };

    public enum ConnectionFilter
    {
        Equal,
        Greater,
        GreaterOrEqual,
        Less,
        LessOrEqual,
        NotEqual,
        None  //means that every sender value will be sent to listener
    }

    public enum ConnectionCalculation
    {
        Proportional,  //procentowo przelicza
        Addition,
        Subtraction,
        Product,
        Division,
        BooleanNot,
        BooleanAnd,
        BooleanOr,
        None
    }
}
