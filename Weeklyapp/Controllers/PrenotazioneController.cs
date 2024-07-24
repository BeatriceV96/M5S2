﻿using Microsoft.AspNetCore.Mvc;
using Weeklyapp.Services;
using Weeklyapp.DataLayer.Entities;

namespace Weeklyapp.Controllers
{
    public class PrenotazioniController : Controller
    {
        private readonly PrenotazioneService _prenotazioneService;

        public PrenotazioniController(PrenotazioneService prenotazioneService)
        {
            _prenotazioneService = prenotazioneService;
        }

        public IActionResult Index()
        {
            var prenotazioni = _prenotazioneService.GetAll();
            return View(prenotazioni);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PrenotazioneEntity prenotazione)
        {
            if (ModelState.IsValid)
            {
                _prenotazioneService.Create(prenotazione);
                return RedirectToAction("Index");
            }
            return View(prenotazione);
        }

        public IActionResult Edit(int id)
        {
            var prenotazione = _prenotazioneService.GetById(id);
            if (prenotazione == null)
            {
                return NotFound();
            }
            return View(prenotazione);
        }

        [HttpPost]
        public IActionResult Edit(int id, PrenotazioneEntity prenotazione)
        {
            if (id != prenotazione.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _prenotazioneService.Update(prenotazione);
                return RedirectToAction("Index");
            }
            return View(prenotazione);
        }

        public IActionResult Delete(int id)
        {
            var prenotazione = _prenotazioneService.GetById(id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            return View(prenotazione);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _prenotazioneService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}