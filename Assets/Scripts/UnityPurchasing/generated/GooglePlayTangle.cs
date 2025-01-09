// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("K5NHXubZf+DHEAOfSJ2oMHKj3C3FiMbgKC/OD/Hz49nk4aOzHglTsX9giLmLCDXE5C9vYd47dpRyg9hjd528LJTUAdkvc6nrBvQJeVB6CGHTwLvK9K1ihzKY1My9lCyPshj2+qWMmYXvpAm8g0r/VDkBB+Jds5rB3G7tztzh6uXGaqRqG+Ht7e3p7O+Id1leCu9dBz1/daJ9lUGDmUjGamZsYo5wpnfywtlvw6VpLWAvXq/8+KYPBpOaXlpxmcNoNGxrpJg+Axi86XsvBJzubzCYbnJPfaiv6eiWHIOri8w4vY4n3mjMhgeT//iARjBXUL3cY4nRzVE4mek0CLkysgL2oKpu7ePs3G7t5u5u7e3sUj5V++XnwmXaGY58Kh0DKe7v7ezt");
        private static int[] order = new int[] { 13,2,5,12,4,8,13,9,9,10,13,11,12,13,14 };
        private static int key = 236;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
