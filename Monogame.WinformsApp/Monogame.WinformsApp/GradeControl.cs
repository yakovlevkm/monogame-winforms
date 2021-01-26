using System;
using System.Collections.Specialized;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.Controls;
using SharpDX.MediaFoundation;

namespace Monogame.WinformsApp
{
    public class GradeControl : MonoGameControl
    {
        private Texture2D _arrow;
        private SpriteBatch _spriteBatch;
        private Texture2D _grade;
        private float angle = 0.0f;
        private float _gradeScale;
        private bool _sceneInitialized;
        private float _arrowX;
        private float _arrowY;
        private float _arrowScale;
        private int t; 

        protected override void Initialize()
        {
            base.Initialize();
            using (var file = new FileStream(".\\Content\\arrow.png", FileMode.Open))
            {
                _arrow = Texture2D.FromStream(GraphicsDevice, file);
            }

            using (var file = new FileStream(".\\Content\\grade.png", FileMode.Open))
            {
                _grade = Texture2D.FromStream(GraphicsDevice, file);
            }
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _sceneInitialized = true;

            CalculatePositions();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //this.Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (!_sceneInitialized) return;

            CalculatePositions();
        }

        private void CalculatePositions()
        {
            _gradeScale = this.Width / (float)_grade.Width;
            _arrowX = this.Width / 2;
            _arrowScale = 1.35f;
            _arrowY = _grade.Width * 0.265f * _arrowScale;
        }

        protected override void Draw()
        {
            base.Draw();
            t += 1;
            var f = 0.2;
            var a = (float)Math.Sin(2 * Math.PI * f * t / 70.0);

            this.angle = a * 0.85f;
            if (this.angle > 2 * MathHelper.Pi) this.angle = 0.0f;

            GraphicsDevice.Clear(Color.White);
            //GraphicsDevice.RasterizerState = RasterizerState.CullNone;

            //float scale = (float) (_newTop / _arrow.Height * 7.5);
            //float yPos = (float) (_newTop + _arrow.Height * scale);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_grade, new Vector2(0, 0), new Rectangle(0,0,_grade.Width, _grade.Height), Color.White, 0.0f,
                new Vector2(0.0f), new Vector2(_gradeScale), SpriteEffects.None, 1);
            _spriteBatch.Draw(
                _arrow,
                //new Vector2(300, 550),
                new Vector2(_arrowX, _arrowY),
                new Rectangle(0, 0, _arrow.Width, _arrow.Height),
                Color.White,
                angle ,
                //0.0f,
                new Vector2(_arrow.Width / 2.0f, _arrow.Height * 0.98f),
                new Vector2(_arrowScale),
                SpriteEffects.None,
                1
            );

            _spriteBatch.End();
        }
    }
}
