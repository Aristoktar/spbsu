using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics.Intergration {
	public enum IntegrationType {
		EulerMethod = 0,
		EulerMethodImplicit = 1,
		RungeKutta4 = 4,
		Iterative = 3,
		PoincareMap= 2,
		DormandPrince = 5,
		Symplectic4=6,
		EulerMethodSymplectic = 7
		
		
	}
}
