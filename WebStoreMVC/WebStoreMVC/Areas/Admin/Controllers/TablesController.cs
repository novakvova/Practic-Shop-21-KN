using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;

namespace AspnetCoreMvcFull.Controllers;

[Area("Admin")]
public class TablesController : Controller
{
  public IActionResult Basic() => View();
}
