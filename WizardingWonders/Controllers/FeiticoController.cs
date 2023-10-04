using Microsoft.AspNetCore.Mvc;
using WizardingWonders.Models;

namespace WizardingWonders.Controllers;

public class FeiticoController : Controller
{
    private static List<Feitico> _lista = new List<Feitico>();
    private static int _count = 0;
    
    [HttpPost]
    public IActionResult Cadastrar(Feitico feitico)
    {
        feitico.Id = ++_count;
        _lista.Add(feitico);
        TempData["msg"] = "Feitiço cadastrado com sucesso!";
        return RedirectToAction("Cadastrar");
    }
    
    [HttpPost]
    public IActionResult Editar(Feitico feitico)
    {
        var index = _lista.FindIndex(f => f.Id == feitico.Id);
        _lista[index] = feitico;
        TempData["msg"] = "Feitiço atualizado com sucesso!";
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult Excluir(int id)
    {
        var f = _lista.First(f =>  f.Id == id);
        _lista.Remove(f);
        TempData["msg"] = "Feitiço removido com sucesso!";
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View(_lista);
    }
    
    [HttpGet]
    public IActionResult Cadastrar()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult Editar(int id)
    {
        var feitico = _lista.First(f => f.Id == id);
        return View(feitico);
    }
    
    [HttpGet]
    public IActionResult Buscar(string termoBuscado)
    {
        List<Feitico> feiticos;
        if (!string.IsNullOrEmpty(termoBuscado))
        {
            feiticos = _lista
                .Where(f => f.Nome.Contains(termoBuscado, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        else
        {
            feiticos = _lista;
        }

        return View("Index", feiticos);
    }
}