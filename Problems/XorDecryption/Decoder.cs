using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.XorDecryption
{
    public class Decoder
    {
        public void Decode(byte[] cipherBytes, byte[] key, byte[] plainBytes)
        {
            for (var i = 0; i < cipherBytes.Length; i++)
            {
                var keyIndex = i % key.Length;
                plainBytes[i] = (byte)(cipherBytes[i] ^ key[keyIndex]);
            }
        }
    }
}
