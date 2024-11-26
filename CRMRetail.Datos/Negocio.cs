using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Datos
{
    /// <summary>
    /// Acceso a las clases 
    /// </summary>
    public class Negocio
    {
        public Tablas.Clientes clientes;
        public Tablas.Configuracion configuracion;
        public Tablas.Marketing marketing;
        public Tablas.MarketingClientes marketingclientes;
        public Tablas.MarketingCorreo marketingcorreo;
        public Tablas.MarketingCorreoPlantillas marketingcorreoplantillas;
        public Tablas.MarketingRecordatorios marketingrecordatorios;
        public Tablas.Menu menu;
        public Tablas.Productos productos;
        public Tablas.Reportes reportes;
        public Tablas.Roles roles;
        public Tablas.Usuarios usuarios;
        public Tablas.UsuariosRoles usuariosroles;
        public Tablas.Ventas ventas;
        public Tablas.VentasProductos ventasproductos;
        public Tablas.CatEstados catEstados;
        public Tablas.CatPoblacion catPoblacion;
        public Tablas.CatColonias catColonias;
        public Tablas.CatCP catCP;
        public Tablas.Cliente cliente;
        public Tablas.Direccion direccion;
        public Tablas.Control_Archivos control_archivos;
        public Tablas.CatSucursal catSucursal;
        public Tablas.Producto producto;
        public Tablas.PromocionProducto promocionProducto;
        public Tablas.ArticuloImg articuloImg;
        public Tablas.CatHorarios catHorarios;
        public Tablas.Venta venta;
        public Tablas.VentaDireccion ventaDireccion;
        public Tablas.VentaProducto ventaProducto;
        public Tablas.Encuesta encuesta;
        public Negocio()
        {
            clientes = new Tablas.Clientes();
            encuesta = new Tablas.Encuesta();
            configuracion = new Tablas.Configuracion();
            marketing = new Tablas.Marketing();
            marketingclientes = new Tablas.MarketingClientes();
            marketingcorreo = new Tablas.MarketingCorreo();
            marketingcorreoplantillas = new Tablas.MarketingCorreoPlantillas();
            marketingrecordatorios = new Tablas.MarketingRecordatorios();
            menu = new Tablas.Menu();
            productos = new Tablas.Productos();
            reportes = new Tablas.Reportes();
            roles = new Tablas.Roles();
            usuarios = new Tablas.Usuarios();
            usuariosroles = new Tablas.UsuariosRoles();
            ventas = new Tablas.Ventas();
            ventasproductos = new Tablas.VentasProductos();
            catEstados = new Tablas.CatEstados();
            catPoblacion = new Tablas.CatPoblacion();
            catColonias = new Tablas.CatColonias();
            catCP = new Tablas.CatCP();
            cliente = new Tablas.Cliente();
            direccion = new Tablas.Direccion();
            control_archivos = new Tablas.Control_Archivos();
            catSucursal = new Tablas.CatSucursal();
            producto = new Tablas.Producto();
            promocionProducto = new Tablas.PromocionProducto();
            articuloImg = new Tablas.ArticuloImg();
            catHorarios = new Tablas.CatHorarios();
            venta = new Tablas.Venta();
            ventaDireccion = new Tablas.VentaDireccion();
            ventaProducto = new Tablas.VentaProducto();
        }
    }
}
