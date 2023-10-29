using lab3.DAO;
using lab3.Model;

CruFacultades db = new CruFacultades();
facultades fa = new facultades();

bool vali1 = true;
int IdWidth = 9;
int NomWidth = 40;
int coordth = 22;
int asigwidth = 15;
int docentwidth = 4;

Console.WriteLine("Registro de facultades");

while (vali1 == true)
{
    Console.Write("\n\tMenu  \n1- Agregar facultad \n2- Actualizar facultad \n3- Ver lista de facultades \n4- Salir \n-> ");
    var menu = int.Parse(Console.ReadLine());

    bool Vali2 = true;

    switch (menu)
    {
        case 1:
            while (Vali2 == true)
            {
                Console.WriteLine("\n\tAgregar Facultad");

                Console.Write("\nIngrese el nombre: ");
                fa.nombre = Console.ReadLine();
                Console.Write("Ingrese el coordinador: ");
                fa.coordinador = Console.ReadLine();
                Console.Write("Ingrese las asignaturas: ");
                fa.asignaturas = int.Parse(Console.ReadLine());
                Console.Write("Ingrese los docente: ");
                fa.docentes = int.Parse(Console.ReadLine());
                db.CreateFacultad(fa);

                Console.WriteLine($"\nLos datos de la facultad de {fa.nombre} han sido agregados con exito");
                bool Vali3 = false;
                do
                {
                    Console.Write("\nDesea seguir agregando otra facultad s/n: ");
                    var menu3 = Console.ReadLine().ToLower().Trim();

                    switch (menu3)
                    {
                        case "s":
                            Vali2 = true;
                            Vali3 = true;
                            break;
                        case "n":
                            Vali2 = false;
                            Vali3 = true;
                            break;
                        default:
                            Console.WriteLine("\nError: Se ingresó una letra diferente de 's' o 'n'");
                            break;
                    }
                } while (!Vali3);
            }
            break;

        case 2:
            while (Vali2 == true)
            {

                Console.WriteLine($"\n{"Codigo".PadRight(IdWidth)} {"Nombre".PadRight(NomWidth)}");
                Console.WriteLine(new string('-', IdWidth + NomWidth + 8));
                foreach (var i in db.ViewFacultades())
                {
                    Console.WriteLine($"{i.id.ToString().PadRight(IdWidth)} {i.nombre.PadRight(NomWidth)}  ");
                }
                Console.Write("\nIngrese el codigo ha actualizar: ");
                var buscar = db.Facultadindivi(int.Parse(Console.ReadLine()));
                var Lector = 1;
                switch (Lector)
                {
                    case 1:
                        Console.Write("\nIngrese el nombre: ");
                        buscar.nombre = Console.ReadLine();
                        break;
                }
                db.UpdateFacul(buscar, Lector);

                Console.WriteLine("\nSe ha actualizado de manera correcta");

                bool Vali3 = false;
                do
                {
                    Console.Write("\nDesea seguir actualizando s/n: ");
                    var menu3 = Console.ReadLine().ToLower().Trim();

                    switch (menu3)
                    {
                        case "s":
                            Vali2 = true;
                            Vali3 = true;
                            break;
                        case "n":
                            Vali2 = false;
                            Vali3 = true;
                            break;
                        default:
                            Console.WriteLine("\nError: Se ingresó una letra diferente de 's' o 'n'");
                            break;
                    }
                } while (!Vali3);
            }
            break;

        case 3:
            var ListarEstudiante = db.ViewFacultades();

            Console.WriteLine($"\n{"Codigo".PadRight(IdWidth)} {"Nombre".PadRight(NomWidth)} {"Coordinadores".PadRight(coordth)} {"Asignaturas".PadRight(asigwidth)} {"Docentes".PadRight(docentwidth)}");

            Console.WriteLine(new string('-', IdWidth + NomWidth + coordth + asigwidth + docentwidth + 8));

            foreach (var i in ListarEstudiante)
            {
                Console.WriteLine($"{i.id.ToString().PadRight(IdWidth)} {i.nombre.PadRight(NomWidth)} {i.coordinador.PadRight(coordth)} {i.asignaturas.ToString().PadRight(asigwidth)} {i.docentes.ToString().PadRight(docentwidth)}   |");
            }
            Console.WriteLine(new string('-', IdWidth + NomWidth + coordth + asigwidth + docentwidth + 8));

            break;

        case 4:
            vali1 = false;
            break;
    }
}
