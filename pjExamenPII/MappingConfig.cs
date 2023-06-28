using AutoMapper;
using pjExamenPII.Models.Dto;
using pjExamenPII.Models;
using pjExamenPII.Models.Dto;

namespace pjExamenPII
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {


            CreateMap<Productos, ProductosDto>().ReverseMap();
            CreateMap<Productos, ProductosCreateDto>().ReverseMap();
            CreateMap<Productos, ProductosUpdateDto>().ReverseMap();


            CreateMap<Clientes, ClientesDto>().ReverseMap();
            CreateMap<Clientes, ClientesUpdateDto>().ReverseMap();
            CreateMap<Clientes, ClientesCreateDto>().ReverseMap();

            CreateMap<Facturas, FacturasDto>().ReverseMap();
            CreateMap<Facturas, FacturasCreateDto>().ReverseMap();
            CreateMap<Facturas, FacturasUpdateDto>().ReverseMap();

            CreateMap<DetalleFactura, DetalleFacturaDto>().ReverseMap();
            CreateMap<DetalleFactura, DetalleFacturaCreateDto>().ReverseMap();
            CreateMap<DetalleFactura, DetalleFacturaUpdateDto>().ReverseMap();
        }

    }
}
