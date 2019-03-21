using System;
using System.Reflection;
using System.Reflection.Emit;
using Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public static class TypeGenerator
    {
        public static Assembly GenerateController()
        {
            AppDomain Domain = AppDomain.CurrentDomain;
            AssemblyName assemblyName = new AssemblyName("DynamicContollersAssembly");
            ModuleBuilder moduleBuilder = null;
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(
                assemblyName,
                AssemblyBuilderAccess.Run);
            moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name);

            var controllerBuilder =
                moduleBuilder.DefineType("DynamicApi", TypeAttributes.Class | TypeAttributes.Public);
            controllerBuilder.DefineDefaultConstructor(MethodAttributes.Public);
            controllerBuilder.SetCustomAttribute(new CustomAttributeBuilder(typeof(ApiControllerAttribute).GetConstructor(Type.EmptyTypes),new object[]{}));

            var methodBuilder =
                controllerBuilder.DefineMethod("DynamicMethod", MethodAttributes.Public, typeof(string), null);
            methodBuilder.SetCustomAttribute(new CustomAttributeBuilder(typeof(HttpGetAttribute).GetConstructor(Type.EmptyTypes),new object[]{}));
            methodBuilder.SetCustomAttribute(new CustomAttributeBuilder(
                typeof(RouteAttribute).GetConstructor(new Type[] {typeof(string)}),
                new object[]{"dynamicmethod"}
                ));

            var generator = methodBuilder.GetILGenerator();
            LocalBuilder local = generator.DeclareLocal(typeof(string));
            generator.Emit(OpCodes.Nop);
            generator.Emit(OpCodes.Ldstr, "String from Dynamic Controller");
            generator.Emit(OpCodes.Stloc_0);
            generator.Emit(OpCodes.Ldloc_0);
            generator.Emit(OpCodes.Nop);
            generator.Emit(OpCodes.Ret);


            var inputParameters = new Type[] {typeof(SimpleData)};
            
            var methodBuilder2 =
                controllerBuilder.DefineMethod("Simple", MethodAttributes.Public,typeof(SimpleData), inputParameters);
            
            var paramBuilder = methodBuilder2.DefineParameter(1, ParameterAttributes.In, "data");
            paramBuilder.SetCustomAttribute(new CustomAttributeBuilder(typeof(FromBodyAttribute).GetConstructor(Type.EmptyTypes),new object[]{}));
            
            methodBuilder2.SetCustomAttribute(new CustomAttributeBuilder(typeof(HttpGetAttribute).GetConstructor(Type.EmptyTypes),new object[]{}));
            methodBuilder2.SetCustomAttribute(new CustomAttributeBuilder(
                typeof(RouteAttribute).GetConstructor(new Type[] {typeof(string)}),
                new object[]{"simple2"}
            ));
            generator = methodBuilder2.GetILGenerator();
            generator.Emit(OpCodes.Ldarg_1);
            generator.Emit(OpCodes.Ret);
            
            Activator.CreateInstance(controllerBuilder.CreateType());

            return assemblyBuilder;

        }
        
        
        
    }
}