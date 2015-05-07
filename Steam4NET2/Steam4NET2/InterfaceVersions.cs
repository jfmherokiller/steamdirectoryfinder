using System;

namespace Steam4Net
{
    internal class InterfaceVersions
    {
        public static string GetInterfaceIdentifier(Type steamClass)
        {
            foreach (
                InteropHelp.InterfaceVersionAttribute attribute in
                    steamClass.GetCustomAttributes(typeof(InteropHelp.InterfaceVersionAttribute), false))
            {
                return attribute.Identifier;
            }

            throw new Exception("Version identifier not found for class " + steamClass);
        }
    }
}