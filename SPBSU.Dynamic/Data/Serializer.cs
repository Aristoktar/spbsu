using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SPBSU.Dynamic.Data {
	public class Serializer {
		public void SerializeObject ( string filename , EquationsSet objectToSerialize ) {
			Stream stream = File.Open ( filename , FileMode.Create );
			BinaryFormatter bFormatter = new BinaryFormatter ();
			bFormatter.Serialize ( stream , objectToSerialize );
			stream.Close ();
		}

		public EquationsSet DeSerializeObject ( string filename ) {
			EquationsSet objectToDeSerialize;
			Stream stream = File.Open ( filename , FileMode.Open );
			BinaryFormatter bFormatter = new BinaryFormatter ();
			objectToDeSerialize = (EquationsSet) bFormatter.Deserialize ( stream );
			stream.Close ();
			return objectToDeSerialize;
		}
	}
}
