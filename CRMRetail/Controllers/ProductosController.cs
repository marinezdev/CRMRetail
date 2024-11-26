using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using m = CRMRetail.Modelos;

namespace CRMRetail.Controllers
{
    public class ProductosController : Utilidades.Comun
    {
        public ActionResult Index()
        {
            List<m.Producto> productos = n.producto.Producto_Seleccionar();

            ViewBag.Poductos = productos;
            return View();
        }
        [HttpPost]
        public JsonResult Producto_Seleccionar_Id(m.Producto producto)
        {
            m.Producto producto1 = n.producto.Producto_Seleccionar_Id(producto);
            m.PromocionProducto promocionProducto = n.promocionProducto.PromocionProducto_Seleccionar_IdProducto(producto);
            m.ArticuloImg articuloImg = n.articuloImg.ProductoImg_Seleccionar_IdProducto(producto);

            Validacion jsonObject = new Validacion()
            {
                Producto = new 
                {
                    Id = producto1.Id,
                    Nombre = producto1.Nombre,
                    SKU = producto1.SKU,
                    Descripcion = producto1.Descripcion,
                    PrecioDistribuidor = producto1.PrecioDistribuidor,
                    PrecioPublico = producto1.PrecioPublico,
                    PrecioDemo = producto1.PrecioDemo,
                    Activo = producto1.Activo,
                    IdCategoria = producto1.IdCategoria,
                    Categoria = producto1.Categoria
                },
                Promocion = new
                {
                    FechaInicio = promocionProducto.FechaInicio,
                    FechaFin = promocionProducto.FechaFin,
                    Precio = promocionProducto.Precio
                },
                ProductoImg = new {
                    Descripcion = articuloImg.Descripcion
                }
            };


            return Json(jsonObject);
        }


        public class Validacion
        {
            public object Producto { get; set; }
            public object Promocion { get; set; }
            public object ProductoImg { get; set; }
        }

        /// <summary>
        /// CARGA DE NUEVOS PRODUCTOS
        /// </summary>
        /// <returns></returns>
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CargaImagen(m.Control_Archivos control_Archivos)
        {
            string DirectorioUsuario = Server.MapPath("~") + "\\ProductosImagenes\\";
            string DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\ProductosImagenes\\";

            List<m.ArticuloImg> LstArticuloImg = new List<m.ArticuloImg>();

            if (Session["Imagenes"] != null)
            {
                LstArticuloImg = (List<m.ArticuloImg>)Session["Imagenes"];
            }

            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i];
                m.ArticuloImg _artiucloImg = new m.ArticuloImg();
                _artiucloImg = NuevoArchivo(file, DirectorioUsuario, DirectorioURL);

                if (_artiucloImg.NmArchivo != null)
                {
                    LstArticuloImg.Add(_artiucloImg);
                }
            }

            Session["Imagenes"] = LstArticuloImg;

            return Json(LstArticuloImg);
        }

        public m.ArticuloImg NuevoArchivo(HttpPostedFileBase Archivo, string DirectorioUsuario, string DirectorioURL)
        {
            m.ArticuloImg _inmueblesImg = new m.ArticuloImg();
            String FileExtension = Path.GetExtension(Archivo.FileName).ToLower();

            if (!Directory.Exists(DirectorioUsuario))
            {
                Directory.CreateDirectory(DirectorioUsuario);
            }

            if (".jpg".Contains(FileExtension) ^ ".png".Contains(FileExtension) ^ ".jpeg".Contains(FileExtension))
            {

                m.Control_Archivos archivo = n.control_archivos.NuevoArchivo();
                string NombreArchivo = archivo.Id.ToString().PadLeft(12, '0');

                Image image = ResizeImage(Image.FromStream(Archivo.InputStream, true, true), 640, 640);
                image.Save(DirectorioUsuario + NombreArchivo + FileExtension);

                _inmueblesImg.IdArchivo = archivo.Id;
                _inmueblesImg.NmArchivo = NombreArchivo + FileExtension;
                _inmueblesImg.NmOriginal = Archivo.FileName;
                _inmueblesImg.Activo = 1;
                _inmueblesImg.Descripcion = DirectorioURL + NombreArchivo + FileExtension;

            }

            return _inmueblesImg;
        }

        public static Image ResizeImage(Image srcImage, int newWidth, int newHeight)
        {
            using (Bitmap imagenBitmap = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppRgb))
            {
                imagenBitmap.SetResolution(
                   Convert.ToInt32(srcImage.HorizontalResolution),
                   Convert.ToInt32(srcImage.HorizontalResolution));

                using (Graphics imagenGraphics = Graphics.FromImage(imagenBitmap))
                {
                    imagenGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                    imagenGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    imagenGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    imagenGraphics.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight), new Rectangle(0, 0, srcImage.Width, srcImage.Height), GraphicsUnit.Pixel);
                    MemoryStream imagenMemoryStream = new MemoryStream();
                    imagenBitmap.Save(imagenMemoryStream, ImageFormat.Jpeg);
                    srcImage = Image.FromStream(imagenMemoryStream);
                }
            }
            return srcImage;
        }

        [HttpPost]
        public JsonResult OrdenarImagenes(m.NuevoArticuloImg nuevoArticuloImg)
        {
            List<m.ArticuloImg> LstArticuloImg = new List<m.ArticuloImg>();
            List<m.ArticuloImg> LstArticuloImgNuevo = new List<m.ArticuloImg>();

            if (Session["Imagenes"] != null)
            {
                LstArticuloImg = (List<m.ArticuloImg>)Session["Imagenes"];
            }

            // TOMA LA IMAGEN ESCOGIDA
            for (int i = 0; i < LstArticuloImg.Count; i++)
            {
                if (LstArticuloImg[i].IdArchivo == nuevoArticuloImg.ArticuloImg.IdArchivo)
                {
                    LstArticuloImgNuevo.Add(LstArticuloImg[i]);
                }
            }

            // LLEGA EL LSITADO
            for (int i = 0; i < LstArticuloImg.Count; i++)
            {
                if (LstArticuloImg[i].IdArchivo != nuevoArticuloImg.ArticuloImg.IdArchivo)
                {
                    LstArticuloImgNuevo.Add(LstArticuloImg[i]);
                }
            }

            Session["Imagenes"] = LstArticuloImgNuevo;

            return Json(LstArticuloImgNuevo);
        }

        [HttpPost]
        public JsonResult EliminarImagen(m.NuevoArticuloImg nuevoArticuloImg)
        {
            string DirectorioUsuario = Server.MapPath("~") + "\\ProductosImagenes\\";
            List<m.ArticuloImg> LstArticuloImg = new List<m.ArticuloImg>();
            if (Session["Imagenes"] != null)
            {
                LstArticuloImg = (List<m.ArticuloImg>)Session["Imagenes"];
            }

            for (int i = 0; i < LstArticuloImg.Count; i++)
            {
                if (LstArticuloImg[i].IdArchivo == nuevoArticuloImg.ArticuloImg.IdArchivo)
                {
                    System.IO.File.Delete(DirectorioUsuario + LstArticuloImg[i].NmArchivo);
                    LstArticuloImg.Remove(LstArticuloImg[i]);
                }
            }

            Session["Imagenes"] = LstArticuloImg;

            return Json(LstArticuloImg);
        }

        [HttpPost]
        public JsonResult BuscarSKU(m.Producto producto)
        {
            m.Producto producto1 = n.producto.Producto_Seleccionar_SKU(producto.SKU);
            m.Mensaje mensaje = new m.Mensaje();

            if(producto1.Id > 0)
            {   
                mensaje.Respuesta = true;
                mensaje.RespuestaText = producto1.SKU;
            }
            else
            {
                mensaje.Respuesta = false;
                mensaje.RespuestaText = producto1.SKU;
            }

            return Json(producto1);
        }

        [HttpPost]
        public JsonResult RegistraNuevo_Articulo(m.Producto producto)
        {
            List<m.ArticuloImg> LstArticuloImg = new List<m.ArticuloImg>();
            m.Mensaje mensaje = new m.Mensaje();

            if (Session["Imagenes"] != null)
            {
                LstArticuloImg = (List<m.ArticuloImg>)Session["Imagenes"];
            }

            if (LstArticuloImg.Count > 0)
            {

                if (String.IsNullOrEmpty(producto.Descripcion))
                {
                    producto.Descripcion = "";
                }
                if (String.IsNullOrEmpty(producto.PrecioDemo.ToString()))
                {
                    producto.PrecioDemo = 0;
                }

                // REGISTRAR EL PORODUCTO.
                mensaje = n.producto.Producto_Agregar(producto);
                
                if (mensaje.Respuesta)
                {
                    // REGISTRAR LA PROMOCION SI EXISTE.
                    if (producto.Precio > 0)
                    {
                        m.PromocionProducto promocionProducto = new m.PromocionProducto();
                        promocionProducto.FechaInicio = producto.FechaInicio;
                        promocionProducto.FechaFin = producto.FechaFin;
                        promocionProducto.Precio = producto.Precio;
                        promocionProducto.IdProducto = Convert.ToInt32(mensaje.RespuestaText);

                        n.promocionProducto.PromocionProducto_Agregar(promocionProducto);
                    }
                    // REGISTRAR LAS IMAGENES.
                    foreach (var ArticuloImg in LstArticuloImg)
                    {
                        ArticuloImg.IdProducto = Convert.ToInt32(mensaje.RespuestaText);
                        n.articuloImg.ProductoImg_Agregar(ArticuloImg);
                    }

                    Session["Imagenes"] = null;
                }
            }
            else
            {
                mensaje.Respuesta = false;
                mensaje.RespuestaText = "Debes de agregar por lómenos 1 imagen del productro.";
            }

            return Json(mensaje);
        }

        [HttpPost]
        public JsonResult Modifica_Articulo(m.Producto producto)
        {
            List<m.ArticuloImg> LstArticuloImg = new List<m.ArticuloImg>();
            m.Mensaje mensaje = new m.Mensaje();

            if (Session["Imagenes"] != null)
            {
                LstArticuloImg = (List<m.ArticuloImg>)Session["Imagenes"];
            }

            if (LstArticuloImg.Count > 0)
            {

                if (string.IsNullOrEmpty(producto.Descripcion))
                {
                    producto.Descripcion = "";
                }
                if (string.IsNullOrEmpty(producto.PrecioDemo.ToString()))
                {
                    producto.PrecioDemo = 0;
                }

                // Modificar el producto

                mensaje = n.producto.Modificar(producto);

                // REGISTRAR LAS IMAGENES.
                foreach (var ArticuloImg in LstArticuloImg)
                {
                    ArticuloImg.IdProducto = producto.Id;
                    n.articuloImg.ProductoImg_Agregar(ArticuloImg);
                    n.articuloImg.Productos_Modificar_Imagen(ArticuloImg);
                }

                if (mensaje.Respuesta)
                {
                    // REGISTRAR LA PROMOCION SI EXISTE.
                    if (producto.Precio > 0)
                    {
                        m.PromocionProducto promocionProducto = new m.PromocionProducto();
                        promocionProducto.FechaInicio = producto.FechaInicio;
                        promocionProducto.FechaFin = producto.FechaFin;
                        promocionProducto.Precio = producto.Precio;
                        promocionProducto.IdProducto = Convert.ToInt32(mensaje.RespuestaText);

                        //n.promocionProducto.PromocionProducto_Agregar(promocionProducto);
                    }
                    // Regristrar las imágenes
                    foreach (var ArticuloImg in LstArticuloImg)
                    {
                        ArticuloImg.IdProducto = Convert.ToInt32(mensaje.RespuestaText);
                        //n.articuloImg.ProductoImg_Agregar(ArticuloImg);
                    }

                    Session["Imagenes"] = null;
                }
            }
            else
            {
                mensaje.Respuesta = false;
                mensaje.RespuestaText = "Debe agregar por lo menos una imágen del producto.";
            }

            return Json(mensaje);
        }

        [HttpPost]
        public ActionResult Agregar(string Nombre, string SKU, string Descripcion, int Categoria, decimal PrecioDistribuidor, decimal PrecioPublico, string Activo, decimal OtroPrecio1, decimal OtroPrecio2, decimal OtroPrecio3)
        {
            m.Productos items = new m.Productos()
            {
                Nombre = Nombre,
                SKU = SKU,
                Descripcion = Descripcion,
                Categoria = Categoria,
                PrecioDistribuidor = PrecioDistribuidor,
                PrecioPublico = PrecioPublico,
                Activo = Activo == "on" ? true : false,
                OtroPrecio1 = OtroPrecio1,
                OtroPrecio2 = OtroPrecio2,
                OtroPrecio3 = OtroPrecio3
            };
            ViewData["Mensaje"] = "Exitoso";
            //n.productos.Agregar(items);
            return View("Index", n.productos.Seleccionar());
        }

        [HttpGet]
        public ActionResult Modificar(int id)
        {
            ViewBag.idProducto = id;

            ViewBag.ClientesPorProducto = n.productos.SeleccionarClientesPorProducto(id);
            return View(n.productos.SeleccionarPorId(id));
        }

        [HttpPost]
        public ActionResult Modificar(string Nombre, string SKU, string Descripcion, int Categoria, decimal PrecioDistribuidor,  
        decimal PrecioPublico, string Activo, decimal OtroPrecio1, decimal OtroPrecio2, decimal OtroPrecio3, int Id)
        {
            m.Productos items = new m.Productos()
            {
                Nombre = Nombre,
                SKU = SKU,
                Descripcion = Descripcion,
                Categoria = Categoria,
                PrecioDistribuidor = PrecioDistribuidor,
                PrecioPublico = PrecioPublico,
                Activo = Activo == "on" ? true : false,
                OtroPrecio1 = OtroPrecio1,
                OtroPrecio2 = OtroPrecio2,
                OtroPrecio3 = OtroPrecio3,
                Id = Id
            };
            ViewData["Mensaje"] = "ExitosoModificado";
            n.productos.Modificar(items);
            return View("Index", n.productos.Seleccionar());
        }

        [HttpPost]
        public JsonResult AgregarOferta(m.PromocionProducto producto)
        {
            m.PromocionProducto oferta = n.producto.AgregarPromocion(producto);

            return Json(oferta);
        }
        //Procesos Json

        public JsonResult SubirImagen()
        {
            // checar si el usuario seleccionó un archivo para subir
            if (Request.Files.Count > 0)
            {
                try
                {
                    var nombre = Request.Form.GetValues(0);
                    var sku = Request.Form.GetValues(1);
                    var descripcion = Request.Form.GetValues(2);
                    var categoria = Request.Form.GetValues(3);
                    var preciopublico = Request.Form.GetValues(4);
                    var preciodistribuidor = Request.Form.GetValues(5);
                    var activo = Request.Form.GetValues(6);
                    var otroprecio1 = Request.Form.GetValues(7);
                    var otroprecio2 = Request.Form.GetValues(8);
                    var otroprecio3 = Request.Form.GetValues(9);

                    HttpFileCollectionBase files = Request.Files;

                    HttpPostedFileBase file = files[0];                    
                    string fileName = file.FileName;

                    var nombr = fileName.Substring(0, fileName.IndexOf("."));
                    var extension = fileName.Substring(fileName.LastIndexOf("."));
                    var nombrcompuesto = nombr + "_" + sku[0] + extension;
                    fileName = nombrcompuesto;

                    // crear un directorio para subir los archivos si no existe
                    string ruta1 = Path.Combine(Server.MapPath("~/ProductosImagenes/"), fileName);
                                      
                    if (ruta1.Contains(fileName))
                    {
                        m.Productos items = new m.Productos()
                        {
                            Nombre = nombre[0],
                            SKU = sku[0],
                            Descripcion = descripcion[0],
                            Categoria = int.Parse(categoria[0]),
                            PrecioPublico = decimal.Parse(preciopublico[0]),
                            PrecioDistribuidor = decimal.Parse(preciodistribuidor[0]),
                            Imagen = fileName,
                            Activo = activo[0] == "1" ? true : false,
                            OtroPrecio1 = otroprecio1[0].ToString() == "" ? 0 : decimal.Parse(otroprecio1[0]),
                            OtroPrecio2 = otroprecio2[0].ToString() == "" ? 0 : decimal.Parse(otroprecio2[0]),
                            OtroPrecio3 = otroprecio3[0].ToString() == "" ? 0 : decimal.Parse(otroprecio3[0])

                        };
                        var respuesta = n.productos.Agregar(items);

                        if (respuesta == 2) //el sku ya existe
                        {
                            return Json(2, JsonRequestBehavior.AllowGet);
                        }
                        //Si el archivo existe no lo creará
                        if (System.IO.File.Exists(ruta1))
                        {
                            return Json(3, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            // guardar el archivo
                            file.SaveAs(ruta1);
                        }
                        return Json(respuesta, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception e)
                {
                    return Json("error" + e.Message);
                }
            }

            return Json("Nada");
        }

        public JsonResult ModificarImagen()
        {
            // checar si el usuario seleccionó un archivo para subir
            if (Request.Files.Count > 0)
            {
                try
                {
                    var id2 = Request.Form.GetValues(0);
                    var sku = Request.Form.GetValues(1);

                    HttpFileCollectionBase files = Request.Files;

                    HttpPostedFileBase file = files[0];
                    string fileName = file.FileName;

                    var nombr = fileName.Substring(0, fileName.IndexOf("."));
                    var extension = fileName.Substring(fileName.LastIndexOf("."));
                    var nombrcompuesto = nombr + "_" + sku[0] + extension;
                    fileName = nombrcompuesto;

                    // crear un directorio para subir los archivos si no existe
                    string ruta1 = Path.Combine(Server.MapPath("~/ProductosImagenes/"), fileName);

                    if (System.IO.File.Exists(ruta1))
                    {
                        return Json(2, JsonRequestBehavior.AllowGet);
                    }

                    // guardar el archivo
                    file.SaveAs(ruta1);
                    
                    n.productos.ModificarImagen(fileName, int.Parse(id2[0].ToString()));

                    return Json(0, JsonRequestBehavior.AllowGet);
                    
                }
                catch (Exception e)
                {
                    return Json("error" + e.Message);
                }
            }

            return Json("Nada");
        }

        public JsonResult ProductoSeleccionarPorId(int id)
        {
            return Json(n.productos.SeleccionarPorId(id), JsonRequestBehavior.AllowGet);
        }

        

    }
}
