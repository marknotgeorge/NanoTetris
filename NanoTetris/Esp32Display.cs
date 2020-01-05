using System;
using System.Collections;
using TetrisEngine;
using Windows.Devices.Gpio;

namespace NanoTetris
{
    public class Esp32Display : IDisplay
    {
        private GpioController gpioController;

        private GpioPin _startPin;
        private GpioPin _selectPin;
        private GpioPin _rotatePin;
        private GpioPin _firePin;
        private GpioPin _upPin;
        private GpioPin _downPin;
        private GpioPin _leftPin;
        private GpioPin _rightPin;

        private bool _isQuitPressed = false;

        private Stack _buttonPressStack;

        // Board dimensions;
        private int _blockSizeInPixels = 15;

        private int _boardHeightInBlocks = 20;
        private int _boardWidthInBlocks = 10;

        private Position _boardOriginInPixels = new Position(10, 10);
        private Position _nextPieceOriginInPixels = new Position(170, 250);

        public Esp32Display()
        {
            gpioController = GpioController.GetDefault();
            _buttonPressStack = new Stack();

            // Set up buttons
            setUpButton(_startPin, Buttons.Start);
            setUpButton(_selectPin, Buttons.Select);
            setUpButton(_rotatePin, Buttons.Rotate);
            setUpButton(_firePin, Buttons.Fire);
            setUpButton(_upPin, Buttons.Up);
            setUpButton(_downPin, Buttons.Down);
            setUpButton(_leftPin, Buttons.Left);
            setUpButton(_rightPin, Buttons.Right);

            // TODO: Set up display...
        }

        private void setUpButton(GpioPin pin, Buttons pinNumber)
        {
            pin = gpioController.OpenPin((int)pinNumber);
            pin.SetDriveMode(GpioPinDriveMode.InputPullUp);
            pin.ValueChanged += buttonPressed;
        }

        private void buttonPressed(object sender, GpioPinValueChangedEventArgs e)
        {
            if (e.Edge == GpioPinEdge.FallingEdge)
            {
                var pin = (GpioPin)sender;

                if (pin != null)
                {
                    var button = (Buttons)pin.PinNumber;

                    if (button == Buttons.Select)
                    {
                        _isQuitPressed = true;
                    }

                    _buttonPressStack.Push(button);
                }
            }
        }

        public int BlockSizeInPixels()
        {
            return _blockSizeInPixels;
        }

        public int BoardHeightInPixels()
        {
            return _boardHeightInBlocks * _blockSizeInPixels;
        }

        public Position BoardOriginInPixels()
        {
            return _boardOriginInPixels;
        }

        public int BoardWidthInPixels()
        {
            return _boardWidthInBlocks * _blockSizeInPixels;
        }

        public void ClearScreen()
        {
            throw new NotImplementedException();
        }

        public void DrawBlock(int x, int y, ColorRGB color)
        {
            throw new NotImplementedException();
        }

        public void DrawFixedAreas(Board board)
        {
            throw new NotImplementedException();
        }

        public void DrawRectangle(int x0, int y0, int x1, int y1, int color, bool fill = true)
        {
            throw new NotImplementedException();
        }

        public bool IsQuitPressed()
        {
            return _isQuitPressed;
        }

        public Position NextPieceOriginInPixels()
        {
            return _nextPieceOriginInPixels;
        }

        public GameButton PollButtons()
        {
            if (_buttonPressStack.Count == 0)
            {
                return GameButton.None;
            }
            else
            {
                var buttonPressed = (Buttons)_buttonPressStack.Pop();

                switch (buttonPressed)
                {
                    case Buttons.Start:
                        return GameButton.Start;

                    case Buttons.Select:
                        return GameButton.Select;

                    case Buttons.Rotate:
                        return GameButton.Rotate;

                    case Buttons.Up:
                        return GameButton.Up;

                    case Buttons.Down:
                        return GameButton.Down;

                    case Buttons.Left:
                        return GameButton.Left;

                    case Buttons.Right:
                        return GameButton.Right;

                    case Buttons.Fire:
                        return GameButton.Drop;

                    default:
                        return GameButton.None;
                }
            }
        }

        public void UpdateScreen()
        {
            throw new NotImplementedException();
        }

        public int BoardWidthInBlocks()
        {
            return _boardWidthInBlocks;
        }

        public int BoardHeightInBlocks()
        {
            return _boardHeightInBlocks;
        }
    }
}