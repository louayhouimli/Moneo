using Microsoft.EntityFrameworkCore;

namespace Moneo.Api.Database;

public class MoneoDbContext(DbContextOptions<MoneoDbContext> options) : DbContext(options);
