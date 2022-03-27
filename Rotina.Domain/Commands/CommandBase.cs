using System;
using System.Reflection;

namespace Rotina.Domain.Commands
{
    public abstract class CommandBase
    {
        public string Id { get; set; }

        public virtual void Verify()
        {
            Type t = GetType();
            PropertyInfo[] props = t.GetProperties();

            foreach (var prop in props)
            {
                if (prop.PropertyType == typeof(DateTime))
                {
                    if (Convert.ToDateTime(prop.GetValue(this)) == new DateTime(0001, 01, 01))
                    {
                        prop.SetValue(this, new DateTime(1900, 01, 01));
                    }
                }

                if (prop.PropertyType == typeof(string))
                {
                    // se a string estiver escrito string => passa para ""
                    if (Convert.ToString(prop.GetValue(this)) == default)
                    {
                        prop.SetValue(this, "");
                    }
                }
            }
        }
    }
}
