using System;
using Spectre.Console;

namespace AsmForThreadsStream
{
    internal class Lamp
    {
        private struct LampData
        {
            public int X, Y, W, H;
            public Color Color;
        }

        private static LampData[] lamps = new LampData[]
        {
            new LampData() { X = 2, Y = 2, W = 15, H = 15, Color = Color.Red },
            new LampData() { X = 20, Y = 20, W = 15, H = 15, Color = Color.Green },
            new LampData() { X = 40, Y = 20, W = 15, H = 15, Color = Color.Blue },
            new LampData() { X = 0, Y = 30, W = 15, H = 15, Color = Color.Yellow },
        };

        private static int _index;

        private static Canvas _canvas = new Canvas(60, 60);

        private LampData _data;

        public Lamp()
        {
            Console.CursorVisible = false;
            _data = lamps[_index];
            _index++;
        }

        public void TurnOn()
        {
            DrawRectangle(_data);
        }

        public void TurnOff()
        {
            var blackData = _data;
            blackData.Color = Color.Default;
            DrawRectangle(blackData);
        }

        private void DrawRectangle(LampData ld)
        {
            AnsiConsole.Clear();

            for (int i = 0; i < ld.W; i++)
            {
                for (int j = 0; j < ld.H; j++)
                {
                    _canvas.SetPixel(ld.X + i, ld.Y + j, ld.Color);
                }
            }

            AnsiConsole.Write(_canvas);
        }
    }
}
