using BackendDevelopmentTask.BLL.Models;
using BackendDevelopmentTask.DAL.Entities;
using Mapster;

namespace BackendDevelopmentTask;

public static class MapsterConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<NodeEntity, NodeModel>.NewConfig()
            .Ignore(dest => dest.ParentNode)
            .Ignore(dest => dest.ChildNodes);

        TypeAdapterConfig<NodeModel, NodeEntity>.NewConfig()
            .Ignore(dest => dest.ParentNode)
            .Ignore(dest => dest.ChildNodes);
    }
}