using System;
using System.Collections.Generic;
using System.Linq;

namespace M05_UF3_P3_Frogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //primer booleano, carril hacia dponde se mueve
            //seundo booleano el objeto afecta al jugador
            //tercer booleano si el carril puede matar al jugador

            //preparar los datos, aqui indicaremos el valor de cada linea, las colisiones contra los carros que pasa
            //si podemos estar en los carriles
            //que caracteres va ver en cada linea
            //en que direccion va ir
            Lane[] lanes = new Lane[10];
            lanes[0] = new Lane(2, false, ConsoleColor.Green, true, false, 0f, Utils.charCars, Utils.colorsLogs.ToList());
            lanes[1] = new Lane(3, true, ConsoleColor.Blue, false, true, 1f, Utils.charLogs, Utils.colorsLogs.ToList());
            lanes[2] = new Lane(4, false, ConsoleColor.Blue, false, true, 1f, Utils.charLogs, Utils.colorsLogs.ToList());
            lanes[3] = new Lane(5, true, ConsoleColor.Blue, false, true, 1f, Utils.charLogs, Utils.colorsLogs.ToList());
            lanes[4] = new Lane(6, false, ConsoleColor.Blue, false, true, 1f, Utils.charLogs, Utils.colorsLogs.ToList());
            lanes[5] = new Lane(7, false, ConsoleColor.Green, true, false, 0f, Utils.charCars, Utils.colorsLogs.ToList());
            lanes[6] = new Lane(8, false, ConsoleColor.Black, true, false, 0.2f, Utils.charCars, Utils.colorsLogs.ToList());
            lanes[7] = new Lane(9, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, Utils.colorsLogs.ToList());
            lanes[8] = new Lane(10, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, Utils.colorsLogs.ToList());
            lanes[9] = new Lane(11, false, ConsoleColor.Green, true, false, 0f, Utils.charCars, Utils.colorsLogs.ToList());
            //Secrea al objeto que representara al personaje
            Player player = new Player();
           
            Utils.GAME_STATE gameState = Utils.GAME_STATE.RUNNING;
            while (gameState == Utils.GAME_STATE.RUNNING)
            {
                foreach (var lane in lanes)
                {
                    lane.Update();
                }
                //determinara la direccion en la que se mueve el jugador
                Vector2Int tecla = Utils.Input();
                //llamando al jugador player.update , guardaremos su estado en gameState
                gameState = player.Update(tecla, lanes.ToList());
                Console.Clear();
                foreach (Lane lane in lanes)
                {
                
                    lane.Draw();
                }
               
                //dibuja al jugador teniendo en cuenta en que linea esta, por si logramos llegar a la linea primera de arriba, entonces ya hemos ganado la partida
                player.Draw(lanes.ToList());

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                //caracter que estara al lado del jugador para que nos podamos ubicar en el mapa
                Console.Write("_");
                //me veifique si el jugador ha llegado a la primera linea de arriba me salte al enum de WIN
                if(player.pos.y == lanes[0].posY)
                {
                    gameState= Utils.GAME_STATE.WIN;

                }
                //controlara los fotogramas del juego
                TimeManager.NextFrame();
            }

            //limpiar consola , si gane que me muestre el mensaje ganador, y si perdi que me muestre el mansaje indicando que he perdido la partida
            Console.Clear();
            Console.WriteLine(gameState == Utils.GAME_STATE.WIN ? "Has ganado, Felicidades !!" : "has perdido, intenta la proxima...");
        }

    }
}