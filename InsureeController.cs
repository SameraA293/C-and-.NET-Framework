[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType")] Insuree insuree)
{
    if (ModelState.IsValid)
    {
        decimal quote = 50m; // Base quote

        // Age logic
        int age = DateTime.Now.Year - insuree.DateOfBirth.Year;
        if (insuree.DateOfBirth > DateTime.Now.AddYears(-age)) age--; // Adjust for birthdate not yet reached

        if (age <= 18)
            quote += 100;
        else if (age >= 19 && age <= 25)
            quote += 50;
        else
            quote += 25;

        // Car year logic
        if (insuree.CarYear < 2000)
            quote += 25;
        if (insuree.CarYear > 2015)
            quote += 25;

        // Car make/model logic
        if (insuree.CarMake.ToLower() == "porsche")
        {
            quote += 25;
            if (insuree.CarModel.ToLower() == "911 carrera")
                quote += 25;
        }

        // Speeding tickets
        quote += insuree.SpeedingTickets * 10;

        // DUI adjustment
        if (insuree.DUI)
            quote *= 1.25m;

        // Coverage adjustment
        if (insuree.CoverageType.ToLower() == "full")
            quote *= 1.5m;

        insuree.Quote = quote;

        db.Insurees.Add(insuree);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    return View(insuree);
}
