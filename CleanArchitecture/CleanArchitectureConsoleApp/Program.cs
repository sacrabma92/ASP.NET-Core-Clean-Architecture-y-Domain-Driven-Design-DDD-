using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();

//await AddNewRecords();
//await QueryFilter();
//await QueryMethos();
//await QueryLinq();
//await TrackingAndNotTracking();
//await AddNewStreamerWithVideo();
await MultipleEntitiesQuery();

Console.WriteLine("Persione cualquier tecla para termina rl programa");
Console.ReadKey();

async Task MultipleEntitiesQuery()
{
    //var videoWithActores = await dbContext.Videos.Include(q => q.Actores).FirstOrDefaultAsync(q => q.Id == 1);

    //var actor = await dbContext.Actor.Select(q => q.Nombre).ToListAsync();

    var videoWithDirector = await dbContext.Videos
        .Where(q => q.Director != null)
        .Include(x => x.Director)
        .Select(q =>
            new
            {
                Director_Nombre_Completo = $"{q.Director.Nombre} {q.Director.Apellido}",
                Movie = q.Nombre
            }
        ).ToListAsync();

    foreach(var pelicula in videoWithDirector)
    {
        Console.WriteLine($"{pelicula.Movie} - {pelicula.Director_Nombre_Completo}");
    }
}

async Task AddNewStreamerWithVideo()
{
    var pantaya = new Streamer
    {
        Nombre = "Pantaya",
        Url = "urldepruebas"
    };

    var hungerGames = new Video
    {
        Nombre = "Hunger Games",
        Streamer = pantaya,
    };

    await dbContext.AddAsync(hungerGames);
    await dbContext.SaveChangesAsync();
}

async Task TrackingAndNotTracking()
{
    var streamerWhithTracking = await dbContext.Streamers.FirstOrDefaultAsync(x => x.Id == 1);
    var streamerWhihtNoTracking = await dbContext.Streamers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2);

    streamerWhithTracking.Nombre = "Netflix Super";
    streamerWhihtNoTracking.Nombre = "Amazon Video Plus";

    await dbContext.SaveChangesAsync();
}

async Task QueryLinq()
{
    Console.WriteLine($"Ingrese el servicio de streaming");
    var streamerNombre = Console.ReadLine();

    var streamers = await (from i in dbContext.Streamers
                           where EF.Functions.Like(i.Nombre, $"%{streamerNombre}%")
                           select i).ToListAsync();

    foreach(var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}

async Task QueryMethos()
{
    var stremar = dbContext.Streamers;
    var firstAsync = await stremar.Where(x => x.Nombre.Contains('a')).FirstAsync();
    var firstOrDefaultAsync = await stremar.Where(x => x.Nombre.Contains('e')).FirstOrDefaultAsync();
    var firstOrDefaulV2 = await stremar.FirstOrDefaultAsync(x => x.Nombre.Contains('e'));
    var singleAsync = await stremar.SingleAsync();
}

async Task QueryFilter()
{
    Console.WriteLine($"Ingrese una compañia de streaming");
    var streamingNombre = Console.ReadLine();
    var streamers = await dbContext.Streamers.Where(x => x.Nombre.Equals(streamingNombre) ).ToListAsync();
    
    foreach(var stremer in streamers)
    {
        Console.WriteLine($"{stremer.Id} - {stremer.Nombre}");
    }

    var streamerPartialResults = await dbContext.Streamers.Where(x => x.Nombre.Contains(streamingNombre)).ToListAsync();

    foreach (var streamer in streamerPartialResults)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}

void QueryStreaming()
{
    var streamers = dbContext!.Streamers.ToList();

    foreach( var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}

async Task AddNewRecords()
{
    Streamer streamer = new()
    {
        Nombre = "Disney",
        Url = "https://www.disney.com"
    };

    dbContext!.Streamers!.Add(streamer);
    await dbContext.SaveChangesAsync();


    var movies = new List<Video>
{
    new Video
    {
        Nombre = "La Cenicienta",
        StreamerId = streamer.Id
    },
    new Video
    {
        Nombre = "1001 Dalmatas",
        StreamerId = streamer.Id
    },
    new Video
    {
        Nombre = "El Jorobado de Notredame",
        StreamerId = streamer.Id
    },
    new Video
    {
        Nombre = "Star Wars",
        StreamerId = streamer.Id
    }
};

    await dbContext.AddRangeAsync(movies);
    await dbContext.SaveChangesAsync();
}