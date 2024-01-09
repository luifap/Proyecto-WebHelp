using WebHelp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting.Server;

using WebHelp.Services.Contrato;
using WebHelp.Services.Implementacion;

using AutoMapper;
using WebHelp.DTOs;
using WebHelp.Utilidades;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DbempleadoContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

builder.Services.AddScoped<IAreaService, AreaService>();
builder.Services.AddScoped<ISubareaService, SubareaService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


#region PETICIONES API REST
app.MapGet("/area/lista", async(
    IAreaService _areaServicio,
    IMapper _mapper
    ) =>
{

    var listaArea = await _areaServicio.GetList();
    var listaAreaDTO = _mapper.Map<List<AreaDTO>>(listaArea);

    if (listaAreaDTO.Count > 0)
        return Results.Ok(listaAreaDTO);
    else
        return Results.NotFound();
});

app.MapGet("/subarea/lista", async (
    ISubareaService _subareaServicio,
    IMapper _mapper
    ) =>
{

    var listaSubarea = await _subareaServicio.GetList();
    var listaSubareaDTO = _mapper.Map<List<SubareaDTO>>(listaSubarea);

    if (listaSubareaDTO.Count > 0)
        return Results.Ok(listaSubareaDTO);
    else
        return Results.NotFound();
});

app.MapGet("/empleado/lista", async (
    IEmpleadoService _empleadoServicio,
    IMapper _mapper
    ) =>
{

    var listaEmpleado = await _empleadoServicio.GetList();
    var listaEmpleadoDTO = _mapper.Map<List<EmpleadoDTO>>(listaEmpleado);

    if (listaEmpleadoDTO.Count > 0)
        return Results.Ok(listaEmpleadoDTO);
    else
        return Results.NotFound();
});

app.MapPost("/empleado/guardar", async (
    EmpleadoDTO modelo,
    IEmpleadoService _empleadoServicio,
    IMapper _mapper
    ) => { 

        var _empleado = _mapper.Map<Empleado>(modelo);
        var _empleadoCreado = await _empleadoServicio.Add(_empleado);

        if (_empleadoCreado.IdEmpleado != 0)
            return Results.Ok(_mapper.Map<EmpleadoDTO>(_empleadoCreado));
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
});


app.MapPut("/empleado/actualizar/{idEmpleado}", async (
    int idEmpleado,
    EmpleadoDTO modelo,
    IEmpleadoService _empleadoServicio,
    IMapper _mapper
    ) => {

        var _encontrado = await _empleadoServicio.Get(idEmpleado);

        if (_encontrado is null) return Results.NotFound();

        var _empleado = _mapper.Map<Empleado>(modelo);

        _encontrado.Nombres = _empleado.Nombres;
        _encontrado.Apellidos = _empleado.Apellidos;
        _encontrado.TipoDocumento = _empleado.TipoDocumento;
        _encontrado.NumeroDocumento = _empleado.NumeroDocumento;
        _encontrado.FechaContrato = _empleado.FechaContrato;
        _encontrado.Pais = _empleado.Pais;
        _encontrado.IdArea = _empleado.IdArea;
        _encontrado.IdSubarea = _empleado.IdSubarea;

        var respuesta = await _empleadoServicio.Update(_encontrado);

        if(respuesta)
            return Results.Ok(_mapper.Map<EmpleadoDTO>(_encontrado));
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);

    });
app.MapDelete("/empleado/eliminar/{idEmpleado}", async (
    int idEmpleado,
    IEmpleadoService _empleadoServicio
    ) => {

        var _encontrado = await _empleadoServicio.Get(idEmpleado);

        if (_encontrado is null) return Results.NotFound();

        var respuesta = await _empleadoServicio.Delete(_encontrado);

        if (respuesta)
            return Results.Ok();
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
    });

#endregion

app.UseCors("NuevaPolitica");

app.Run();

