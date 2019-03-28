using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto1.Models;

namespace Proyecto1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialCursoController : ControllerBase
    {


        // GET: api/MaterialCurso/5
        [HttpGet("{id}", Name = "Get7")]
        public string Get(int id)
        {
            //MaterialApoyo nuevo = new MaterialApoyo("", "", "", "", 1, 1);
            string query = "Select * from materialapoyo\n" +
                "where idmateria = " + id + ";";
            Conexion conn = new Conexion();
            List<Generico2> lst1 = conn.metodo_consulta(query, 8);
            List<MaterialApoyo> lst = new List<MaterialApoyo>();
            for (int i = 0; i < lst1.Count; i++)
            {
                MaterialApoyo nuevo = new MaterialApoyo(    
                    Convert.ToInt32(lst1[i].Lst[0].Parametro.ToString()),   
                    lst1[i].Lst[1].Parametro.ToString(),   
                    lst1[i].Lst[2].Parametro.ToString(),   
                    lst1[i].Lst[3].Parametro.ToString(),  
                    lst1[i].Lst[5].Parametro.ToString(),   
                    Convert.ToInt32(lst1[i].Lst[6].Parametro.ToString()),   
                    Convert.ToInt32(lst1[i].Lst[7].Parametro.ToString())   
                    );
                lst.Add(nuevo);
            }

            return JsonConvert.SerializeObject(lst);
        }
    }
}
