using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ClinicaExemplo.Domain.Entities;
using ClinicaExemplo.MVC.ViewModels;
using ClinicaExemplo.Application.Interface;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace ClinicaExemplo.MVC.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly IAgendamentoAppService _agendamentoApp;

        public AgendamentoController(IAgendamentoAppService agendamentoApp)
        {
            _agendamentoApp = agendamentoApp;
        }

        // GET: Agendamento
        public ActionResult Index()
        {
            var AgendamentoViewModel = Mapper.Map<IEnumerable<Agendamento>, IEnumerable<AgendamentoViewModel>>(_agendamentoApp.GetAll());

            return View(AgendamentoViewModel);
        }

        public ActionResult ObterEspecialidade()
        {
            string specialistsList = "https://api.feegow.com.br/api/specialties/list";
            string result = null;

            Task.Run(async () =>
            {
                result = await DownloadPorUrl(specialistsList);
            }).Wait();

            //Converter result pra JSON e adicionar conforme modelo abaixo
            var response = JsonConvert.DeserializeObject<RespostaEsp>(result);
            if (response.Success)
            {
                ViewBag.CategoriaId = new SelectList(response.Content, "Especialidade_id", "Nome");
                var listaDropDown = new List<string>() { "CategoriaId" };

                return View("_DropDownView", listaDropDown);
            }

            else return View("_DropDownView", new List<string>());
        }

        public ActionResult ObterProfissional(string id)
        {
            var espec = id.Split(';');
            ViewBag.espc = espec[1];
            string idespc = espec[0]; 
            string profissionalList = "https://api.feegow.com.br/api/professional/list?especialidade_id="+ idespc;
            string result = null;

            Task.Run(async () =>
            {
                result = await DownloadPorUrlProf(profissionalList);
            }).Wait();

            //Converter result pra JSON e adicionar conforme modelo abaixo
            var response = JsonConvert.DeserializeObject<RespostaProf>(result);
            if (response.Success)
            {
                var listaDropDown = response.Content;

                ViewBag.TotEspec = listaDropDown.Count;

                return View("_CarregaProfissional", listaDropDown);
            }

            else return View("_CarregaProfissional", new List<string>());
        }

        public ActionResult ObterSource()
        {
            string sourcelist = "https://api.feegow.com.br/api/patient/list-sources";
            string result = null;

            Task.Run(async () =>
            {
                result = await DownloadPorUrl(sourcelist);
            }).Wait();

            //Converter result pra JSON e adicionar conforme modelo abaixo
            var response = JsonConvert.DeserializeObject<RespostaAgen>(result);
            if (response.Success)
            {
                ViewBag.origem_id = new SelectList(response.Content, "origem_id", "nome_origem");
                var listaDropDown = new List<string>() { "origem_id" };

                return View("_DropDownOrigem", listaDropDown);
            }

            else return View("_DropDownOrigem", new List<string>());
        }

        public async Task<string> DownloadPorUrl(string url)
        {
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add("x-access-token", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJmZWVnb3ciLCJhdWQiOiJwdWJsaWNhcGkiLCJpYXQiOiIxNy0wOC0yMDE4IiwibGljZW5zZUlEIjoiMTA1In0.UnUQPWYchqzASfDpVUVyQY0BBW50tSQQfVilVuvFG38");

                using (var result = await client.GetAsync(url))
                {
                    if (result.IsSuccessStatusCode)
                    {
                        return await result.Content.ReadAsStringAsync();
                    }

                }
            }
            return null;
        }

        public async Task<string> DownloadPorUrlProf(string url)
        {
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add("x-access-token", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJmZWVnb3ciLCJhdWQiOiJwdWJsaWNhcGkiLCJpYXQiOiIxNy0wOC0yMDE4IiwibGljZW5zZUlEIjoiMTA1In0.UnUQPWYchqzASfDpVUVyQY0BBW50tSQQfVilVuvFG38");
                using (var result = await client.GetAsync(url))
                {
                    if (result.IsSuccessStatusCode)
                    {
                        return await result.Content.ReadAsStringAsync();
                    }

                }
            }
            return null;
        }

        // GET: Agendamento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Agendamento/Create
        public ActionResult Create(int Pid, int Eid)
        {
            ViewBag.Pid = Pid;
            ViewBag.Eid = Eid;

            return View("Create");
        }

        // POST: Agendamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(AgendamentoViewModel agendamento)
        {
            if(ModelState.IsValid)
            {
                var agendamentoDomain = Mapper.Map<AgendamentoViewModel, Agendamento>(agendamento);
                _agendamentoApp.Add(agendamentoDomain);

                return RedirectToAction("Index");
            }
            return View(agendamento);

            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Agendamento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Agendamento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Agendamento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Agendamento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
