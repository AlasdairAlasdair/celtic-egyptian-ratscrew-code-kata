using Autofac;

namespace CelticEgyptianRatscrewKata.SnapValidation
{
    public class SnapValidationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AggregateSnapValidator>().AsSelf();

            builder.RegisterType<StandardSnapValidator>().As<ISnapValidator>();
            builder.RegisterType<SandwichSnapValidator>().As<ISnapValidator>();
            builder.RegisterType<DarkQueenSnapValidator>().As<ISnapValidator>();
        }
    }
}