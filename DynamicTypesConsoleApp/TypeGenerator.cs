using System;
using System.Reflection;
using System.Reflection.Emit;

namespace DynamicTypesConsoleApp
{
    public class TypeGenerator
    {
        public static Assembly GenerateController()
        {
            AppDomain Domain = AppDomain.CurrentDomain;
            AssemblyName assemblyName = new AssemblyName("DynamicControllers"){Version = new Version(1,0)};
            ModuleBuilder moduleBuilder = null;
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(
                assemblyName,
#if NET472
                AssemblyBuilderAccess.RunAndSave
#else
                AssemblyBuilderAccess.Run
#endif
                );
            
            moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name);
            
            var controllerBuilder =
                moduleBuilder.DefineType("DynamicApi", TypeAttributes.Public);
            controllerBuilder.DefineDefaultConstructor(MethodAttributes.Public);
            //controllerBuilder.SetCustomAttribute(new CustomAttributeBuilder(typeof(ApiControllerAttribute).GetConstructor(Type.EmptyTypes),new object[]{}));

            var methodBuilder =
                controllerBuilder.DefineMethod("DynamicMethod", MethodAttributes.Public, typeof(string), null);
            
            var generator = methodBuilder.GetILGenerator();
            LocalBuilder local = generator.DeclareLocal(typeof(string));
            generator.Emit(OpCodes.Ldstr, "String from Dynamic Controller");
            generator.Emit(OpCodes.Stloc_0);
            generator.Emit(OpCodes.Ldloc_0);
            generator.Emit(OpCodes.Ret);

            dynamic inst = Activator.CreateInstance(controllerBuilder.CreateType());

            var str = inst.DynamicMethod();

            return assemblyBuilder;

        }
    }
}