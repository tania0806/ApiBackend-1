// using System;
// using System.Collections;
// using System.Data;
// using System.Data.SqlClient;
// using reportesApi.DataContext;
// using reportesApi.Models;
// using System.Collections.Generic;
// using reportesApi.Models.Compras;
// using OfficeOpenXml;
// using Microsoft.AspNetCore.Hosting;
// using System.IO;
// using Microsoft.AspNetCore.Mvc;
// using System.Drawing.Printing;
// namespace reportesApi.Services
// {
//     public class ComprasService
//     {
//         private  string connection;
//         private readonly IWebHostEnvironment _webHostEnvironment;
        
        
//         public ComprasService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
//         {
//              connection = settings.ConnectionString;
//              _webHostEnvironment = webHostEnvironment;
             
//         }

//         public string GetRutaReportes()
//         {
//             return @"C:\Users\User\Documents\GitHub\ApiReportes\templates";
            
//         }

//         public  (MemoryStream, string )ReporteDiasInventario(string FechaInicial, string FechaFinal, int proveedor)
//         {
//             var reporte = this.GetDiasInventario(FechaInicial, FechaFinal, proveedor);
//             ExcelPackage.LicenseContext = LicenseContext.Commercial;
//             string webRootPath = _webHostEnvironment.ContentRootPath;
//             //var fullPath = Server.MapPath(pathFileExcel + nameFileExcel);
//             var fullPath = Path.Combine(webRootPath, "templates/ReporteDias.xlsx");

//             try
//             {
//                 if (System.IO.File.Exists(fullPath))
//                 {
//                     System.IO.File.Delete(fullPath);
//                 }
//                 //FileInfo template = new FileInfo(Server.MapPath("~/templates/ReporteEstadoCuentaProveedorTemplate.xlsx"));
//                 FileInfo template = new FileInfo(Path.Combine(webRootPath, "templates/template.xlsx"));
//                 FileInfo newFile = new FileInfo(fullPath);
//                 int dias = 13;
//                 using (ExcelPackage excelPackage = new ExcelPackage(newFile, template))
//                 {
//                     ExcelWorkbook myWorkbook = excelPackage.Workbook;
//                     ExcelWorksheet myWorksheet = myWorkbook.Worksheets[0];
//                     int i = 3;

//                     myWorksheet.Cells["A1"].Value = "F. Inicial";
//                     myWorksheet.Cells["B1" ].Value = FechaInicial;
//                     myWorksheet.Cells["C1" ].Value = "F. Final";
//                     myWorksheet.Cells["D1" ].Value = FechaFinal;
//                     myWorksheet.Cells["E1"].Value = "dias";
//                     myWorksheet.Cells["F1" ].Value = "12";

//                     myWorksheet.Cells["A2"].Value = "Articulo";
//                     myWorksheet.Cells["B2" ].Value = "Descripcion";
//                     myWorksheet.Cells["C2" ].Value = "Familia";
//                     myWorksheet.Cells["D2" ].Value = "Departamento";
//                     myWorksheet.Cells["E2"].Value = "Ventas DO";
//                     myWorksheet.Cells["F2" ].Value = "Prom Venta DO";
//                     myWorksheet.Cells["G2"].Value = "Teorico DO";
//                     myWorksheet.Cells["H2" ].Value = "D.I DO";
//                     myWorksheet.Cells["I2"].Value = "Ventas Arb";
//                     myWorksheet.Cells["J2" ].Value = "Prom Venta Arb";
//                     myWorksheet.Cells["K2"].Value = "Teorico Arb";
//                     myWorksheet.Cells["L2" ].Value = "D.I Arb";
//                     myWorksheet.Cells["M2"].Value = "Ventas Vill";
//                     myWorksheet.Cells["N2" ].Value = "Prom Venta Vill";
//                     myWorksheet.Cells["O2"].Value = "Teorico Vill";
//                     myWorksheet.Cells["P2" ].Value = "D.I Vill";
//                     myWorksheet.Cells["Q2"].Value = "Ventas All";
//                     myWorksheet.Cells["R2" ].Value = "Prom Venta All";
//                     myWorksheet.Cells["S2"].Value = "Teorico All";
//                     myWorksheet.Cells["T2" ].Value = "D.I All";
//                     myWorksheet.Cells["U2"].Value = "Ventas Petaca";
//                     myWorksheet.Cells["V2" ].Value = "Prom Venta Petaca";
//                     myWorksheet.Cells["W2"].Value = "Teorico Petaca";
//                     myWorksheet.Cells["X2" ].Value = "D.I Petaca";
//                     myWorksheet.Cells["Y2"].Value = "Ventas Mor";
//                     myWorksheet.Cells["Z2" ].Value = "Prom Venta Mor";
//                     myWorksheet.Cells["AA2"].Value = "Teorico Mor";
//                     myWorksheet.Cells["AB2" ].Value = "D.I Mor";
//                     myWorksheet.Cells["AC2" ].Value = "Teorico Cedis";
//                     myWorksheet.Cells["AD2"].Value = "Ventas Totales";
//                     myWorksheet.Cells["AE2" ].Value = "Prom Vta Total";
//                     myWorksheet.Cells["AF2" ].Value = "Teorico Total";
//                     myWorksheet.Cells["AG2" ].Value = "D.I total";

//                     foreach (var registro in reporte)
//                     {

//                         var ventas_totales  = (registro.VentasDo + registro.VentasArb + registro.VentasAll + registro.VentasVill + registro.VentasPet + registro.VentasMor);
                        
//                         myWorksheet.Cells["A" + i].Value = registro.Articulo;
//                         myWorksheet.Cells["B" + i].Value = registro.Descripcion;
//                         myWorksheet.Cells["C" + i].Value = registro.Familia;
//                         myWorksheet.Cells["D" + i].Value = registro.Departamento;
//                         myWorksheet.Cells["E" + i].Value = registro.VentasDo;
//                         myWorksheet.Cells["F" + i].Value = Dividir( registro.VentasDo , dias) ;
//                         myWorksheet.Cells["G" + i].Value = registro.ExisteDo;
//                         myWorksheet.Cells["H" + i].Value = Dividir( registro.ExisteDo ,  Dividir( registro.VentasDo , dias ));
//                         myWorksheet.Cells["I" + i].Value = registro.VentasArb;
//                         myWorksheet.Cells["J" + i].Value = Dividir( registro.VentasArb , dias );
//                         myWorksheet.Cells["K" + i].Value = registro.ExisteArb;
//                         myWorksheet.Cells["L" + i].Value = Dividir( registro.ExisteArb , Dividir (registro.VentasArb , dias) );
//                         myWorksheet.Cells["M" + i].Value = registro.VentasVill;
//                         myWorksheet.Cells["N" + i].Value = Dividir( registro.VentasVill , dias );
//                         myWorksheet.Cells["O" + i].Value = registro.ExisteVill;
//                         myWorksheet.Cells["P" + i].Value = Dividir( registro.VentasVill , Dividir ( registro.VentasVill , dias) );
//                         myWorksheet.Cells["Q" + i].Value = registro.VentasAll;
//                         myWorksheet.Cells["R" + i].Value = Dividir( registro.VentasAll , dias );
//                         myWorksheet.Cells["S" + i].Value = registro.ExisteAll;
//                         myWorksheet.Cells["T" + i].Value = Dividir( registro.ExisteAll ,  Dividir(registro.VentasAll , dias) );
//                         myWorksheet.Cells["U" + i].Value = registro.VentasPet;
//                         myWorksheet.Cells["V" + i].Value = Dividir( registro.VentasPet , dias );
//                         myWorksheet.Cells["W" + i].Value = registro.ExistePet;
//                         myWorksheet.Cells["X" + i].Value = Dividir( registro.ExistePet ,  Dividir(registro.VentasPet , dias) );
//                         myWorksheet.Cells["Y" + i].Value = registro.VentasMor;
//                         myWorksheet.Cells["Z" + i].Value = Dividir( registro.VentasMor , dias ); 
//                         myWorksheet.Cells["AA" + i].Value = registro.ExisteMor ;
//                         myWorksheet.Cells["AB" + i].Value = Dividir( registro.ExisteMor ,  Dividir(registro.VentasMor , dias) );
//                         myWorksheet.Cells["AC" + i].Value = registro.ExisteCedis;
//                         myWorksheet.Cells["AD" + i].Value = ventas_totales;
//                         myWorksheet.Cells["AE" + i].Value = Dividir( ventas_totales , dias );
//                         myWorksheet.Cells["AF" + i].Value = registro.ExisteTotal;
//                         myWorksheet.Cells["AG" + i].Value = Dividir( registro.ExisteTotal , Dividir (ventas_totales , dias) ) ;
//                         i++;
//                     }

//                     excelPackage.Save();
//                 }

//                 var fullPathDownload = fullPath;

//                 var memory = new MemoryStream();
//                 using (var stream = new FileStream(fullPathDownload, FileMode.Open))
//                 {
//                     stream.CopyTo(memory);
//                 }
//                 memory.Position = 0;

//                 // Configura el tipo de contenido correcto según el tipo de archivo.
//                 // Para archivos Excel, puedes usar "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
//                 var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
//                 var fileExt = Path.GetExtension("ReporteDias.xlsx").ToLowerInvariant();
//                 if (fileExt == ".xlsx")
//                 {
//                     contentType = "application/vnd.ms-excel";
//                 }
//                 return (memory, fullPathDownload);
//                 //return File(memory, contentType, Path.GetFileName(filePath));
//                 //return  ruta + "/" +   nameFileExcel;;
//             }
//             catch (Exception Ex)
//             {
//                 throw Ex;
//             }
//         }


//         public  (MemoryStream, string )ReporteCatalogoArticulos(int id_sucursal)
//         {
//             var reporte = this.GetCatalogoArticulos();
//             ExcelPackage.LicenseContext = LicenseContext.Commercial;
//             string webRootPath = _webHostEnvironment.ContentRootPath;
//             //var fullPath = Server.MapPath(pathFileExcel + nameFileExcel);
//             var fullPath = Path.Combine(webRootPath, "templates/ReporteDias.xlsx");

//             try
//             {
//                 if (System.IO.File.Exists(fullPath))
//                 {
//                     System.IO.File.Delete(fullPath);
//                 }
//                 //FileInfo template = new FileInfo(Server.MapPath("~/templates/ReporteEstadoCuentaProveedorTemplate.xlsx"));
//                 FileInfo template = new FileInfo(Path.Combine(webRootPath, "templates/template.xlsx"));
//                 FileInfo newFile = new FileInfo(fullPath);
//                 int dias = 13;
//                 using (ExcelPackage excelPackage = new ExcelPackage(newFile, template))
//                 {
//                     ExcelWorkbook myWorkbook = excelPackage.Workbook;
//                     ExcelWorksheet myWorksheet = myWorkbook.Worksheets[0];
//                     int i = 2;


//                     myWorksheet.Cells["A1"].Value = "Articulo";
//                     myWorksheet.Cells["B1" ].Value = "Descripcion";
//                     myWorksheet.Cells["C1" ].Value = "Familia";
//                     myWorksheet.Cells["D1" ].Value = "Departamento";
//                     myWorksheet.Cells["E1"].Value = "Costo Promedio";
//                     myWorksheet.Cells["F1" ].Value = "PCT IVA";
//                     myWorksheet.Cells["G1"].Value = "PCT IEPS";
//                     myWorksheet.Cells["H1" ].Value = "Costo U Compra";
//                     myWorksheet.Cells["I1"].Value = "Precio venta";
//                     myWorksheet.Cells["J1" ].Value = "Existencia";
//                     myWorksheet.Cells["K1"].Value = "Estatus";

//                     foreach (var registro in reporte)
//                     {

                        
//                         myWorksheet.Cells["A" + i].Value = registro.Codigo;
//                         myWorksheet.Cells["B" + i].Value = registro.Articulo;
//                         myWorksheet.Cells["C" + i].Value = registro.Familia;
//                         myWorksheet.Cells["D" + i].Value = registro.Departamento;
//                         myWorksheet.Cells["E" + i].Value = registro.CostoPromedio;
//                         myWorksheet.Cells["F" + i].Value = registro.Iva;
//                         myWorksheet.Cells["G" + i].Value = registro.Ieps;
//                         myWorksheet.Cells["H" + i].Value = registro.CostoUltimaCompra;
//                         myWorksheet.Cells["I" + i].Value = registro.PrecioVenta;
//                         myWorksheet.Cells["J" + i].Value = registro.Existencia;
//                         myWorksheet.Cells["K" + i].Value = registro.Estatus;
//                         i++;
//                     }

//                     excelPackage.Save();
//                 }

//                 var fullPathDownload = fullPath;

//                 var memory = new MemoryStream();
//                 using (var stream = new FileStream(fullPathDownload, FileMode.Open))
//                 {
//                     stream.CopyTo(memory);
//                 }
//                 memory.Position = 0;

//                 // Configura el tipo de contenido correcto según el tipo de archivo.
//                 // Para archivos Excel, puedes usar "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
//                 var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
//                 var fileExt = Path.GetExtension("ReporteDias.xlsx").ToLowerInvariant();
//                 if (fileExt == ".xlsx")
//                 {
//                     contentType = "application/vnd.ms-excel";
//                 }
//                 return (memory, fullPathDownload);
//                 //return File(memory, contentType, Path.GetFileName(filePath));
//                 //return  ruta + "/" +   nameFileExcel;;
//             }
//             catch (Exception Ex)
//             {
//                 throw Ex;
//             }
//         }

//         public decimal Dividir(decimal numerador, decimal denominador)
//         {
//             if (denominador == 0)
//             {
//                 // Retornamos 0 si el denominador es cero para evitar la división por cero.
//                 return 0;
//             }
//             else
//             {
//                 // Si el denominador no es cero, realizamos la división normalmente.
//                 return numerador / denominador ;
//             }
//         }

//         public List<DiasInventarioModel> GetDiasInventario(string fecha_inicial, string fecha_final, int proveedor)
//         {
            
//             List<DiasInventarioModel> lista = new List<DiasInventarioModel>();
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             ArrayList parametros = new ArrayList();
//             try
//             {
//                 parametros.Add(new SqlParameter { ParameterName = "@pFechaInicial", SqlDbType = SqlDbType.VarChar, Value = fecha_inicial });
//                 parametros.Add(new SqlParameter { ParameterName = "@pFechaFinal", SqlDbType = SqlDbType.VarChar, Value = fecha_final });
//                 parametros.Add(new SqlParameter { ParameterName = "@pProveedor", SqlDbType = SqlDbType.VarChar, Value = proveedor });
//                 DataSet ds = dac.Fill("COM_GetDiasInventario", parametros);
//                 if (ds.Tables[0].Rows.Count > 0)
//                 {
//                     foreach (DataRow row in ds.Tables[0].Rows)
//                     {
//                         lista.Add(new DiasInventarioModel{
//                             Articulo  = row["Articulo"].ToString(),
//                             Descripcion  = row["Descripcion"].ToString(),
//                             Familia  = row["Familia"].ToString(),
//                             Departamento  = row["Departamento"].ToString(),
//                             VentasDo = decimal.Parse(row["VentasDo"].ToString()),
//                             ExisteDo = decimal.Parse(row["ExisteDo"].ToString()),
//                             VentasArb  = decimal.Parse(row["VentasArb"].ToString()),
//                             ExisteArb  = decimal.Parse(row["ExisteArb"].ToString()),
//                             VentasVill  = decimal.Parse(row["VentasVill"].ToString()),
//                             ExisteVill  = decimal.Parse(row["ExisteVill"].ToString()),
//                             VentasAll  = decimal.Parse(row["VentasAll"].ToString()),
//                             ExisteAll  = decimal.Parse(row["ExisteAll"].ToString()),
//                             VentasPet  = decimal.Parse(row["VentasPetaca"].ToString()),
//                             ExistePet  = decimal.Parse(row["ExistePetaca"].ToString()),
//                             VentasMor  = decimal.Parse(row["VentasMorelos"].ToString()),
//                             ExisteMor  = decimal.Parse(row["ExisteMorelos"].ToString()),
//                             VentasTotales  = decimal.Parse(row["VentasTotales"].ToString()),
//                             ExisteCedis  = decimal.Parse(row["ExisteCedis"].ToString()),
//                             ExisteTotal  = decimal.Parse(row["ExisteTotal"].ToString()),
//                         });
//                     }
//                 }
//                 return lista;
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }
           
//         }

//         public List<GetCatalogoArticulos> GetCatalogoArticulos()
//         {
            
//             List<GetCatalogoArticulos> lista = new List<GetCatalogoArticulos>();
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             ArrayList parametros = new ArrayList();
//             try
//             {
//                 DataSet ds = dac.Fill("RPT_GetCatalogoArticulos");
//                 if (ds.Tables[0].Rows.Count > 0)
//                 {
//                     foreach (DataRow row in ds.Tables[0].Rows)
//                     {
//                         lista.Add(new GetCatalogoArticulos{
//                             Articulo  = row["Codigo"].ToString(),
//                             Codigo  = row["Articulo"].ToString(),
//                             Familia  = row["Familia"].ToString(),
//                             Departamento  = row["Departamento"].ToString(),
//                             CostoPromedio = decimal.Parse(row["CostoPromedio"].ToString()),
//                             PrecioVenta = decimal.Parse(row["PrecioVenta"].ToString()),
//                             CostoUltimaCompra = decimal.Parse(row["CostoUltimaCompra"].ToString()),
//                             Iva = int.Parse(row["Iva"].ToString()),
//                             Ieps = int.Parse(row["Ieps"].ToString()),
//                             Existencia = decimal.Parse(row["Existencia"].ToString()),
//                             Estatus = row["Estatus"].ToString(),

//                         });
//                     }
//                 }
//                 return lista;
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }
           
//         }
//         public  (MemoryStream, string )ReporteFaltanteExistencias(int sucursal)
//         {
//             var reporte = this.GetFaltantesExistencia(sucursal);
//             ExcelPackage.LicenseContext = LicenseContext.Commercial;
//             string webRootPath = _webHostEnvironment.ContentRootPath;
//             //var fullPath = Server.MapPath(pathFileExcel + nameFileExcel);
//             var fullPath = Path.Combine(webRootPath, "templates/ReporteFaltantes.xlsx");

//             try
//             {
//                 if (System.IO.File.Exists(fullPath))
//                 {
//                     System.IO.File.Delete(fullPath);
//                 }
//                 //FileInfo template = new FileInfo(Server.MapPath("~/templates/ReporteEstadoCuentaProveedorTemplate.xlsx"));
//                 FileInfo template = new FileInfo(Path.Combine(webRootPath, "templates/template.xlsx"));
//                 FileInfo newFile = new FileInfo(fullPath);
//                 int dias = 13;
//                 using (ExcelPackage excelPackage = new ExcelPackage(newFile, template))
//                 {
//                     ExcelWorkbook myWorkbook = excelPackage.Workbook;
//                     ExcelWorksheet myWorksheet = myWorkbook.Worksheets[0];
//                     int i = 3;

//                     myWorksheet.Cells["A1"].Value = "F. Inicial";
//                     myWorksheet.Cells["B1" ].Value = "";

//                     myWorksheet.Cells["A2"].Value = "Articulo";
//                     myWorksheet.Cells["B2" ].Value = "Descripcion";
//                     myWorksheet.Cells["C2" ].Value = "Cantidad afectar";
//                     myWorksheet.Cells["D2" ].Value = "Existencia";
//                     myWorksheet.Cells["E2"].Value = "Faltante";
//                     myWorksheet.Cells["F2" ].Value = "ENTCOC";
//                     myWorksheet.Cells["G2"].Value = "ENTSOC";
//                     myWorksheet.Cells["H2"].Value = "ENTTRA";
//                     myWorksheet.Cells["I2"].Value = "ETRANS";
//                     myWorksheet.Cells["J2"].Value = "SIROTA";
//                     myWorksheet.Cells["K2"].Value = "DEPARTAMENTO";

//                     foreach (var registro in reporte)
//                     {

                        
//                         myWorksheet.Cells["A" + i].Value = registro.Codigo;
//                         myWorksheet.Cells["B" + i].Value = registro.Descripcion;
//                         myWorksheet.Cells["C" + i].Value = registro.Cantidad;
//                         myWorksheet.Cells["D" + i].Value = registro.Existencia;
//                         myWorksheet.Cells["E" + i].Value = registro.Cantidad - registro.Existencia;
//                         myWorksheet.Cells["F" + i].Value =registro.Entcoc;
//                         myWorksheet.Cells["G" + i].Value = registro.Entsoc;
//                         myWorksheet.Cells["H" + i].Value = registro.Enttra;
//                         myWorksheet.Cells["I" + i].Value = registro.Etrans;
//                         myWorksheet.Cells["J" + i].Value = registro.Sirota;
//                         myWorksheet.Cells["K" + i].Value = registro.Departamento;

                       
//                         i++;
//                     }

//                     excelPackage.Save();
//                 }

//                 var fullPathDownload = fullPath;

//                 var memory = new MemoryStream();
//                 using (var stream = new FileStream(fullPathDownload, FileMode.Open))
//                 {
//                     stream.CopyTo(memory);
//                 }
//                 memory.Position = 0;

//                 // Configura el tipo de contenido correcto según el tipo de archivo.
//                 // Para archivos Excel, puedes usar "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
//                 var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
//                 var fileExt = Path.GetExtension("FaltantesExistencia.xlsx").ToLowerInvariant();
//                 if (fileExt == ".xlsx")
//                 {
//                     contentType = "application/vnd.ms-excel";
//                 }
//                 return (memory, fullPathDownload);
//                 //return File(memory, contentType, Path.GetFileName(filePath));
//                 //return  ruta + "/" +   nameFileExcel;;
//             }
//             catch (Exception Ex)
//             {
//                 throw Ex;
//             }
//         }

//         public List<FaltantesExistencia> GetFaltantesExistencia(int sucursal)
//         {
            
//             List<FaltantesExistencia> lista = new List<FaltantesExistencia>();
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             ArrayList parametros = new ArrayList();
//             try
//             {
//                 parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = sucursal });
//                 DataSet ds = dac.Fill("GetFaltantesExistencias", parametros);
//                 if (ds.Tables[0].Rows.Count > 0)
//                 {
//                     foreach (DataRow row in ds.Tables[0].Rows)
//                     {
//                         lista.Add(new FaltantesExistencia{
//                             Codigo  = row["Articulo"].ToString(),
//                             Descripcion  = row["Descripcion"].ToString(),
//                             Cantidad = decimal.Parse(row["Cantidad"].ToString()),
//                             Existencia = decimal.Parse(row["Existencia"].ToString()),
//                             Entcoc = decimal.Parse(row["Entcoc"].ToString()),
//                             Entsoc = decimal.Parse(row["Entsoc"].ToString()),
//                             Enttra = decimal.Parse(row["Enttra"].ToString()),
//                             Etrans = decimal.Parse(row["Etrans"].ToString()),
//                             Sirota = decimal.Parse(row["Sirota"].ToString()),
//                             Departamento = row["Departamento"].ToString()

//                         });
//                     }
//                 }
//                 return lista;
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }
           
//         }
//     }
// }