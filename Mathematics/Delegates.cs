using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics.Delegates {
	public delegate double functionVector ( double inputX , double[] inputY );

	public delegate double function ( double inputX , double inputY );

	public delegate double functionD ( double t , Dictionary<string , double> f );
}
