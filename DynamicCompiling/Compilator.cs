using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using Microsoft.CSharp;
using Mathematics.Delegates;
using System.Text.RegularExpressions;

namespace DynamicCompiling
{

	
    public class Compilator
    {
		
		private const string FuncTemplate =
			@"
			public static double Func# (double t, Dictionary<string , double> f,Dictionary<string , double> parameter) {
				return <...>;
			}
			>...<";
		Dictionary<string,string> Equations;
		private string Source =
			@"
			using System;
			using System.Collections.Generic;
			namespace CompileSource
			{
			  public static class Funcs
			  {
				>...<
			  }
			}";
		public string PathToFile;
		public string DirectoryToFile;
		//public Compilator (List<string> equations) {
		//	for ( int i = 0 ; i < equations.Count ; i++ ) {
		//		equations[i] = PrepareString ( equations[i] );
		//	}
		//	this.Equations = equations;
		//	for ( int i = 0 ; i < Equations.Count ;i++ ) {
		//		Source = Source.Replace ( ">...<" , FuncTemplate.Replace ( "<...>" , Equations[i] ).Replace ( "#",i.ToString()) );
		//	}
		//	Source = Source.Replace ( ">...<" , "" );
		//	// Настройки компиляции
		//	Dictionary<string , string> providerOptions = new Dictionary<string , string>
		//	{
		//		{"CompilerVersion", "v4.0"}
		//	};
		//	CSharpCodeProvider provider = new CSharpCodeProvider ( providerOptions );
		//	DirectoryToFile = Path.GetTempPath () + @"spbsuTemp";


		//	Directory.CreateDirectory ( DirectoryToFile );
		//	PathToFile = Path.GetTempPath () + @"spbsuTemp\Compiled.dll";

		//	CompilerParameters compilerParams = new CompilerParameters {
		//		OutputAssembly = PathToFile ,
		//		GenerateExecutable = false,
		//		GenerateInMemory = true
		//	};

		//	// Компиляция
			
		//		PathToFile = compilerParams.OutputAssembly.Insert ( compilerParams.OutputAssembly.Length - 4 , "1" );
		//		compilerParams.OutputAssembly = PathToFile;
		//		CompilerResults results = provider.CompileAssemblyFromSource ( compilerParams , Source );
		//		if ( results.Errors.HasErrors )
		//			throw new Exception ();
		//}
		public Compilator ( Dictionary<string,string> equations, Dictionary<string,double> parameters,Dictionary<string,string>.KeyCollection keys = null) {
			
			for(int i=0; i<equations.Count;i++){
				if ( keys == null ) {

					equations[equations.ElementAt ( i ).Key] = PrepareString ( equations.ElementAt ( i ).Value , equations.Keys , parameters.Keys );
				}
				else {
					equations[equations.ElementAt ( i ).Key] = PrepareString ( equations.ElementAt ( i ).Value , keys , parameters.Keys );
				}
				//equations[equations.ElementAt ( i ).Key] = PrepareString ( equations.ElementAt ( i ).Value , "t" );
			}
			this.Equations = equations;
			foreach ( var key in equations.Keys ) {
				Source = Source.Replace ( ">...<" , FuncTemplate.Replace ( "<...>" , equations[key] ).Replace ( "#" , key.ToString () ) );
			}

			Source = Source.Replace ( ">...<" , "" );
			// Настройки компиляции
			Dictionary<string , string> providerOptions = new Dictionary<string , string>
			{
				{"CompilerVersion", "v4.0"}
			};
			CSharpCodeProvider provider = new CSharpCodeProvider ( providerOptions );
			DirectoryToFile = System.Windows.Forms.Application.StartupPath + @"\TempFiles";
			string ttttt = System.Windows.Forms.Application.StartupPath;

			try {
				Directory.Delete ( DirectoryToFile , true );
			}
			catch ( Exception ex ) {
			}
			Directory.CreateDirectory ( DirectoryToFile );
			PathToFile = DirectoryToFile + @"\Compiled.dll";

			CompilerParameters compilerParams = new CompilerParameters {
				OutputAssembly = PathToFile ,
				GenerateExecutable = false
			};

			
			// Компиляция

			PathToFile = compilerParams.OutputAssembly.Insert ( compilerParams.OutputAssembly.Length - 4 , new Random().Next(100000).ToString());
			compilerParams.OutputAssembly = PathToFile;
			CompilerResults results = provider.CompileAssemblyFromSource ( compilerParams , Source );
			if ( results.Errors.HasErrors )
				throw new DynamicCompilationException {
					Message = results.Errors[0].ErrorText
				};
				
		}


		public static string PrepareString (string input,Dictionary<string,string>.KeyCollection keysOfVariables,Dictionary<string,double>.KeyCollection keysOfParameters) {
			string output = input;
			//input = input.ToLower ();
			foreach ( var key in keysOfVariables.Union(keysOfParameters) ) {
				#region Pow
				int powPos = output.IndexOf ( key + "^" ) + key.Length;
				
				while ( powPos - key.Length > 0 ) {
					if ( output[powPos + 1].ToString () == "(" ) {
						int hooks = 1;
						int iteretPos = powPos + 1;
						while ( hooks != 0 ) {
							iteretPos++;
							if ( output[iteretPos].ToString () == "(" ) {
								hooks++;
							}
							if ( output[iteretPos].ToString () == ")" ) {
								hooks--;
							}

						}
						string subToReplaceSource = output.Substring ( powPos + 2 , iteretPos - powPos - 2 );
						string subToReplaceOrigin = output.Substring ( powPos - key.Length , key.Length + 1 + ( iteretPos - powPos ) );
						output = output.Replace ( subToReplaceOrigin , "Math.Pow(" + key + "," + subToReplaceSource + ")" );
					}
					else {
						int iterPos = 0;
						while ( true ) {
							iterPos++;
							if ( iterPos + powPos >= output.Length ) {

								string subToReplaceSource = output.Substring ( powPos + 1 , iterPos - 1 );

								string subToReplaceOrigin = output.Substring ( powPos - key.Length , key.Length  + ( iterPos ) );
								output = output.Replace ( subToReplaceOrigin , "Math.Pow(" + key + "," + subToReplaceSource + ")" );
								break;
							}
							bool find = false;
							switch ( output[powPos + iterPos] ) {
								case '+':
								case '-':
								case '*':
								case '/':
									string subToReplaceSource = output.Substring ( powPos + 1 , iterPos - 1 );
									string subToReplaceOrigin = output.Substring ( powPos - key.Length , key.Length + 1 + ( iterPos - powPos ) );
									output = output.Replace ( subToReplaceOrigin , "Math.Pow(" + key + "," + subToReplaceSource + ")" );
									find = true;
									break;
								default: break;
							}
							if ( find ) {
								break;
							}
						}
					}
					powPos = output.IndexOf ( "^" );
				} 
				#endregion

				if ( key != "t" ) {
					string outputTemp = output;
					//var matchingTemp = Regex.Matches ( outputTemp , @"(^|\W)" + key );
					//foreach ( var t in matchingTemp ) {
					//	outputTemp = outputTemp.Replace ( t.ToString () , " " + t );
					//}
					outputTemp = Regex.Replace ( outputTemp , @"(^|\W)" + key , new MatchEvaluator ( a => {
						return " " + a.Value;
					} ) );

					var matching = Regex.Replace ( outputTemp , @"(^|\W)" + key + @"($|\W)" , new MatchEvaluator ( ( a ) => {
						string outputEvaluator = "";
						if ( !char.IsLetter ( a.Value[0] ) ) {
							outputEvaluator += a.Value[0].ToString ();
						}
						if ( keysOfVariables.Contains ( key ) ) {
							outputEvaluator += "f[\"" + key.ToString () + "\"]";
						}
						else {
							outputEvaluator += "parameter[\"" + key.ToString () + "\"]";
						}
						if ( !char.IsLetter ( a.Value[a.Value.Length - 1] ) ) {
							outputEvaluator += a.Value[a.Value.Length - 1].ToString ();
						}
						return outputEvaluator;
					} ) );
					outputTemp = matching.Replace ( " " , "" );

					output = outputTemp;
				}

				//int passedIndex = 0;
				//int keyPos= output.IndexOf(key,passedIndex);
				
				
					//if(keyPos!=-1 )
					//{
					//	if ( keyPos - 1 > -1 ) {

					//		if ( !Char.IsLetter ( output[keyPos - 1] ) ) {
					//			if ( key != "t" ) {
					//				if ( keysOfVariables.Contains ( key ) ) {

					//					output = output.Replace ( key , "f[\"" + key.ToString () + "\"]" );
					//					keyPos += 4;
					//				}
					//				else {
					//					output = output.Replace ( key , "parameter[\"" + key.ToString () + "\"]" );
					//					passedIndex += 12;
					//				}
					//			}
					//		}
					//		else {
					//			passedIndex = keyPos+1;
					//			keyPos = output.IndexOf ( key , passedIndex );
					//			continue;
					//		}
					//	}
					//	else {
					//		if ( key != "t" ) {
					//			if ( keysOfVariables.Contains ( key ) ) {

					//				output = output.Replace ( key , "f[\"" + key.ToString () + "\"]" );
					//				keyPos += 4;
					//			}
					//			else {
					//				output = output.Replace ( key , "parameter[\"" + key.ToString () + "\"]" );
					//				passedIndex += 12;
					//			}
					//		}
					//	}
					//	passedIndex = keyPos;
					//	keyPos = output.IndexOf ( key , passedIndex );
					//}
				//output = input;
				
					
					output = output
								.Replace ( "sin" , "Math.Sin" )
								.Replace ( "cos" , "Math.Cos" );
				
			}
			
			return output;
		}

		//public List<MethodInfo> GetFuncs () {
		//	Assembly assembly = Assembly.LoadFile ( PathToFile );
		//	Type compiledType = assembly.GetType ( "CompileSource.Funcs" );
		//	List<MethodInfo> output = new List<MethodInfo> ();
		//	var t = compiledType.GetMethods ();
		//	 for ( int i = 0 ; i < Equations.Count ;i++ ) {
		//		 MethodInfo method = compiledType.GetMethod ( "Func" + i.ToString () );
		//		 output.Add ( method );
		//	 }
		//	 return output;
		//}
		public Dictionary<string,functionD> GetFuncs () {
			Assembly assembly = Assembly.LoadFile ( PathToFile );
			Type compiledType = assembly.GetType ( "CompileSource.Funcs" );
			Dictionary<string , functionD> output = new Dictionary<string , functionD> ();
			var t = compiledType.GetMethods ();
			foreach ( var key in Equations.Keys ) {
				MethodInfo method = compiledType.GetMethod ( "Func" + key.ToString () );
				output.Add ( key , (functionD)method.CreateDelegate ( typeof ( functionD ) ) );
			}
			return output;
		}
		
		
    }
}

