using System.Collections.Specialized;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.Controls;

namespace Monogame.WinformsApp
{
    public class GradeControl : MonoGameControl
    {
        private Texture2D _arrow;
        private SpriteBatch _spriteBatch;
        private Texture2D _grade;
        private float angle = 0.0f;

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
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //this.Invalidate();
        }

        protected override void Draw()
        {
            base.Draw();

            this.angle += 0.02f;
            if (this.angle > 2 * MathHelper.Pi) this.angle = 0.0f;

            GraphicsDevice.Clear(Color.White);
            //GraphicsDevice.RasterizerState = RasterizerState.CullNone;

            float arrowX = 250 * 3, arrowY = 200 * 3;
            //float scale = (float) (_newTop / _arrow.Height * 7.5);
            //float yPos = (float) (_newTop + _arrow.Height * scale);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_grade, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(
                _arrow,
                //new Vector2(300, 550),
                new Vector2(arrowX, arrowY),
                new Rectangle(0, 0, _arrow.Width, _arrow.Height),
                Color.White,
                angle ,
                //0.0f,
                new Vector2(_arrow.Width / 2.0f, _arrow.Height * 0.98f),
                new Vector2(1.0f),
                SpriteEffects.None,
                1
            );

            _spriteBatch.End();
        }
    }
}
