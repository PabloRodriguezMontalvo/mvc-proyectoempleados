using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using MvcRrhh.Utils;

namespace MvcRrhh.Servicios
{
    public class Servicios<TModelo>:IServicios<TModelo>
    {
        private readonly String _urlBase;

        public Servicios(String url)
        {
            _urlBase = url;
        }


        public async Task Add(TModelo modelo)
        {
            var serializado = Serializacion<TModelo>.Serializar(modelo);
           
            using (var handler = new HttpClientHandler())
            {
                using (var client = new HttpClient(handler))
                {
                    var contenido = new StringContent(serializado);
                    contenido.Headers.ContentType =
                        new MediaTypeHeaderValue("application/json");

                    await client.PostAsync(new Uri(_urlBase), 
                        contenido);
                }
            }


        }

        public async Task Update(int id, TModelo modelo)
        {
            var serializado = Serializacion<TModelo>.Serializar(modelo);

            using (var handler = new HttpClientHandler())
            {
                using (var client = new HttpClient(handler))
                {
                    var contenido = new StringContent(serializado);
                    contenido.Headers.ContentType =
                        new MediaTypeHeaderValue("application/json");

                    await client.PutAsync(new Uri(_urlBase),
                        contenido);
                }
            }
        }

        public async Task Delete(int id)
        {
           

            using (var handler = new HttpClientHandler())
            {
                using (var client = new HttpClient(handler))
                {
                  

                    await client.DeleteAsync(new Uri(_urlBase+"/"+id));
                }
            }
        }

        public List<TModelo> Get()
        {
            List<TModelo> lista;
            var cl = WebRequest.Create(_urlBase+"/get");
            cl.Method = "GET";
            var res = cl.GetResponse();
            using (var stream = res.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var resultado = reader.ReadToEnd();
                    lista = Serializacion<List<TModelo>>.
                        Deserializar(resultado);

                }
            }

            return lista;
        }

        public List<TModelo> Get(string metodo, string param)
        {
            List<TModelo> lista;
            var cl = WebRequest.Create(_urlBase +"/"+ metodo+"/"+param);
            cl.Method = "GET";
            var res = cl.GetResponse();
            using (var stream = res.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var resultado = reader.ReadToEnd();
                    lista = Serializacion<List<TModelo>>.
                        Deserializar(resultado);

                }
            }

            return lista;
        }

        public TModelo Get(int id)
        {
            TModelo lista;
            var cl = WebRequest.Create(_urlBase + "/porid/"+id);
            cl.Method = "GET";
            var res = cl.GetResponse();
            using (var stream = res.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var resultado = reader.ReadToEnd();
                    lista = Serializacion<TModelo>.
                        Deserializar(resultado);

                }
            }

            return lista;
        }
    }
}