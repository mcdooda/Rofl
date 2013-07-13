using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoflLib;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using RiseEditor.forms;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Windows.Forms;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using RoflLib.io;
using System.Reflection;
using RoflCodeContent.levels.test.particles;
using RoflLib.utils.math;
using RoflLib.io.level;

namespace RiseEditor
{
    public class RiseEditorMode : InputSwitchAppMode
    {
        private enum Action
        {
            None,
            MovingElement,
            MovingVertex,
            RemovingElement,
            MovingCamera,
            ElementProperties,
            AddingParticleEffect,
            RemovingParticleEffect
        }

        private bool resizingEstBound;
        private bool resizingWestBound;
        private bool resizingNorthBound;
        private bool resizingSouthBound;
        private bool movingBounds;
        private Vector2 mouseBoundsRelativePosition;

        private Texture2D vertexHandleTexture;

        private Vertex selectedVertex;
        private LevelElement selectedElement;

        private Vector2 relative; // relative position between mouse and an other object

        private Action action;

        private ParticleEffect currentParticleEffect;

        private MainWindow mainWindow;
        public MainWindow MainWindow { set { mainWindow = value; } }

        private LevelLayer currentLayer;
        public LevelLayer CurrentLayer { get { return currentLayer; } set { currentLayer = value; } }

        private bool saved;
        public bool Saved { get { return saved; } set { saved = value; } }

        private delegate void DrawTabOverlay(GameTime gameTime);
        private Dictionary<string, DrawTabOverlay> drawTabOverlay;

        private delegate void UpdateTabElements(GameTime gameTime);
        private Dictionary<string, UpdateTabElements> updateTabElements;

        public RiseEditorMode(GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics, ContentManager content)
            : base(graphicsDevice, graphics, content)
        {
            action = Action.None;
            saved = false;
            currentParticleEffect = null;

            drawTabOverlay = new Dictionary<string, DrawTabOverlay>();
            drawTabOverlay["Layers"] = DrawLayerOverlay;
            drawTabOverlay["Camera settings"] = DrawLayerOverlay;
            drawTabOverlay["Level bounds"] = DrawBoundsOverlay;

            updateTabElements = new Dictionary<string, UpdateTabElements>();
            updateTabElements["Layers"] = UpdateLayerElements;
            updateTabElements["Camera settings"] = null;
            updateTabElements["Level bounds"] = UpdateBounds;

            resizingNorthBound = false;
            resizingSouthBound = false;
            resizingWestBound = false;
            resizingEstBound = false;
        }

        public override void Initialize()
        {
            base.Initialize();
            selectedVertex = null;
            selectedElement = null;
            relative = new Vector2();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            NewLevel();
            LoadParticleEffects();
            currentLayer = level.PlatformsLayer;
            vertexHandleTexture = content.Load<Texture2D>("vertexhandle");
            renderer.AddUtilityTexture(content, "levelcenter");
            renderer.AddUtilityTexture(content, "particlecenter");
        }

        private void LoadParticleEffects()
        {
            ParticleEffect.Random = random;
            ParticleEffect.ParticleEffects = new Dictionary<string, ParticleEffect>();
            new RoflCodeContent.levels.test.particles.TestEffect(content);
            new RoflCodeContent.levels.plaguejungles.particles.PlagueEffect(content);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            level.UpdateEffects(gameTime);

            if (IsMouseInside())
            {
                mainWindow.GetXnaFrame().Focus();
                mainWindow.HasFocus = false;
            }
            else if (!mainWindow.HasFocus)
            {
                mainWindow.HasFocus = true;
            }

            UpdateCamera(gameTime);

            UpdateTabElements updateFunc = updateTabElements[mainWindow.SelectedTabName];
            if (updateFunc != null)
                updateFunc(gameTime);
        }

        private LevelElement GetSelectedElement()
        {
            Vector2 mouse = GetMouseCameraRelativePositionDepth(currentLayer.Depth);
            LevelElement selected = null;
            foreach (LevelElement element in currentLayer.Elements)
            {
                if (element.Polygon.IsInside(mouse))
                {
                    selected = element;
                    break;
                }
            }
            return selected;
        }

        private Vertex GetSelectedVertex()
        {
            Vector2 mouse = GetMouseCameraRelativePositionDepth(currentLayer.Depth);
            Vertex selected = null;
            float minDstSquared = 100;
            foreach (LevelElement element in currentLayer.Elements)
            {
                foreach (Vertex vertex in element.Polygon.Vertices)
                {
                    float dstSquared = Vector2.DistanceSquared(vertex.Vector2, mouse);
                    if (dstSquared < minDstSquared) // the cursor is near a vertex
                    {
                        selectedVertex = vertex;
                        minDstSquared = dstSquared;
                    }
                }
            }
            return selected;
        }

        private void UpdateLayerElements(GameTime gameTime)
        {
            if (action == Action.MovingCamera)
                return;

            Vector2 mouse = GetMouseCameraRelativePositionDepth(currentLayer.Depth);

            if (!IsMouseLeftPressed() && !IsMouseRightPressed() && action != Action.RemovingElement && action != Action.ElementProperties && action != Action.AddingParticleEffect && action != Action.RemovingParticleEffect)
            {
                action = Action.None;
                selectedVertex = null;

                if (selectedElement != null)
                    selectedElement.Polygon.Color = Color.Blue;

                selectedElement = null;
            }
            else if (action == Action.RemovingElement && IsJustReleased(Keys.LeftShift))
            {
                action = Action.None;
                selectedElement = null;
                SetCursor(Cursors.Default);
            }
            else if (action == Action.AddingParticleEffect && IsJustReleased(Keys.LeftShift))
            {
                action = Action.None;
                currentParticleEffect = null;
                SetCursor(Cursors.Default);
            }
            else if (action == Action.RemovingParticleEffect && IsJustReleased(Keys.LeftShift))
            {
                action = Action.None;
                SetCursor(Cursors.Default);
            }

            switch (action)
            {
                case Action.None:
                    {
                        if (currentLayer == level.PlatformsLayer)
                        {
                            foreach (LevelElement element in level.PlatformsLayer.Elements)
                            {
                                foreach (Vertex vertex in element.Polygon.Vertices)
                                {
                                    if (Vector2.DistanceSquared(vertex.Vector2, mouse) < 100) // the cursor is near a vertex
                                    {
                                        selectedElement = element;
                                        selectedVertex = vertex;
                                        if (IsMouseLeftJustPressed())
                                        {
                                            action = Action.MovingVertex;
                                        }
                                        else if (IsMouseRightJustPressed())
                                        {
                                            element.Polygon.RemoveVertex(vertex);
                                            selectedVertex = null;
                                        }
                                        goto doAction;
                                    }
                                }
                            }
                        }

                        foreach (LevelElement element in currentLayer.Elements)
                        {
                            if (element.Polygon.IsInside(mouse))
                            {
                                selectedElement = element;
                                selectedElement.Polygon.Color = Color.Red;
                                if (IsMouseLeftJustPressed())
                                {
                                    action = Action.MovingElement;
                                    relative.X = mouse.X - element.GetPolygonOrigin().X;
                                    relative.Y = mouse.Y - element.GetPolygonOrigin().Y;
                                }
                                else if (IsMouseRightJustPressed() && currentLayer == level.PlatformsLayer)
                                {
                                    action = Action.MovingVertex;
                                    selectedVertex = element.AddPolygonVertex(mouse);
                                }
                                goto doAction;
                            }
                        }
                    }
                    break;

                case Action.RemovingElement:
                    {
                        LevelElement oldSelectedElement = selectedElement;
                        selectedElement = null;
                        foreach (LevelElement element in currentLayer.Elements)
                        {
                            if (element.Polygon.IsInside(mouse))
                            {
                                selectedElement = element;
                                selectedElement.Polygon.Color = Color.Red;
                                break;
                            }
                        }

                        if (oldSelectedElement != null && oldSelectedElement != selectedElement)
                        {
                            oldSelectedElement.Polygon.Color = Color.Blue;
                        }

                        if (selectedElement != null)
                        {
                            SetCursor(Cursors.No);

                            if (IsMouseLeftJustPressed())
                            {
                                currentLayer.RemoveElement(selectedElement);
                                mainWindow.UpdateLayersNodes();
                                selectedElement = null;

                                if (!IsPressed(Keys.LeftShift))
                                    action = Action.None;

                                SetCursor(Cursors.Default);
                            }
                        }
                        else
                        {
                            SetCursor(Cursors.Default);
                        }
                    }
                    break;

                case Action.ElementProperties:
                    {
                        LevelElement oldSelectedElement = selectedElement;
                        selectedElement = null;
                        foreach (LevelElement element in currentLayer.Elements)
                        {
                            if (element.Polygon.IsInside(mouse))
                            {
                                selectedElement = element;
                                selectedElement.Polygon.Color = Color.Red;
                                break;
                            }
                        }

                        if (oldSelectedElement != null && oldSelectedElement != selectedElement)
                        {
                            oldSelectedElement.Polygon.Color = Color.Blue;
                        }

                        if (selectedElement != null)
                        {
                            SetCursor(Cursors.Help);

                            if (IsMouseLeftJustPressed())
                            {
                                action = Action.None;
                                mainWindow.OpenElementProperties(selectedElement);
                                selectedElement = null;
                                SetCursor(Cursors.Default);
                            }
                        }
                        else
                        {
                            SetCursor(Cursors.Default);
                        }
                    }
                    break;

                case Action.AddingParticleEffect:
                    {
                        if (IsMouseLeftJustPressed())
                        {
                            ParticleEffect particleEffect = currentParticleEffect.New(gameTime, GetMouseCameraRelativePositionDepth(currentLayer.Depth));
                            currentLayer.AddEffect(particleEffect);

                            if (!IsPressed(Keys.LeftShift))
                            {
                                action = Action.None;
                                SetCursor(Cursors.Default);
                            }
                        }
                    }
                    break;

                case Action.RemovingParticleEffect:
                    {
                        ParticleEffect selectedParticleEffect = null;
                        foreach (ParticleEffect particleEffect in currentLayer.ParticleEffects)
                        {
                            if (mouse.X >= particleEffect.Position.X - 16
                             && mouse.X <= particleEffect.Position.X + 16
                             && mouse.Y >= particleEffect.Position.Y - 16
                             && mouse.Y <= particleEffect.Position.Y + 16)
                            {
                                selectedParticleEffect = particleEffect;
                                break;
                            }
                        }

                        if (selectedParticleEffect != null)
                        {
                            SetCursor(Cursors.No);
                            if (IsMouseLeftJustPressed())
                            {
                                currentLayer.RemoveEffect(selectedParticleEffect);
                                if (!IsPressed(Keys.LeftShift))
                                {
                                    action = Action.None;
                                    SetCursor(Cursors.Default);
                                }
                            }
                        }
                        else
                        {
                            SetCursor(Cursors.Default);
                        }
                    }
                    break;
            }

        doAction:
            switch (action)
            {
                case Action.MovingVertex:
                    selectedVertex.X = mouse.X;
                    selectedVertex.Y = mouse.Y;
                    break;

                case Action.MovingElement:
                    selectedElement.SetPosition(mouse - relative);
                    break;
            }
        }

        private void UpdateBounds(GameTime gameTime)
        {
            FloatRectangle levelBounds = level.Bounds;
            Vector2 mouse = GetMouseCameraRelativePosition();
            float margin = 20;

            if (!IsMouseLeftPressed())
            {
                resizingNorthBound = false;
                resizingSouthBound = false;
                resizingEstBound = false;
                resizingWestBound = false;
                movingBounds = false;
            }

            if (movingBounds)
            {
                level.Bounds.Left = mouse.X - mouseBoundsRelativePosition.X;
                level.Bounds.Top = mouse.Y - mouseBoundsRelativePosition.Y;
                mainWindow.UpdateLevelBounds();
            }
            else
            {
                if (resizingEstBound)
                {
                    float left = levelBounds.Left;
                    levelBounds.Left = mouse.X;
                    levelBounds.Width += left - levelBounds.Left;
                    mainWindow.UpdateLevelBounds();
                }
                else if (resizingWestBound)
                {
                    levelBounds.Width += mouse.X - levelBounds.Right;
                    mainWindow.UpdateLevelBounds();
                }

                if (resizingNorthBound)
                {
                    float top = levelBounds.Top;
                    levelBounds.Top = mouse.Y;
                    levelBounds.Height += top - levelBounds.Top;
                    mainWindow.UpdateLevelBounds();
                }
                else if (resizingSouthBound)
                {
                    levelBounds.Height += mouse.Y - levelBounds.Bottom;
                    mainWindow.UpdateLevelBounds();
                }
            }

            if (!resizingEstBound && !resizingWestBound && !resizingNorthBound && !resizingSouthBound
                && mouse.X > levelBounds.Left - margin && mouse.X < levelBounds.Right + margin
                && mouse.Y > levelBounds.Top - margin && mouse.Y < levelBounds.Bottom + margin)
            {
                if (mouse.X < levelBounds.Left + margin)
                    resizingEstBound = true;
                
                else if (mouse.X > levelBounds.Right - margin)
                    resizingWestBound = true;
                

                if (mouse.Y < levelBounds.Top + margin)
                    resizingNorthBound = true;

                else if (mouse.Y > levelBounds.Bottom - margin)
                    resizingSouthBound = true;


                if (resizingEstBound && resizingNorthBound || resizingWestBound && resizingSouthBound)
                    SetCursor(Cursors.SizeNWSE);

                else if (resizingEstBound && resizingSouthBound || resizingWestBound && resizingNorthBound)
                    SetCursor(Cursors.SizeNESW);

                else if (resizingNorthBound)
                    SetCursor(Cursors.SizeNS);

                else if (resizingSouthBound)
                    SetCursor(Cursors.SizeNS);

                else if (resizingWestBound)
                    SetCursor(Cursors.SizeWE);

                else if (resizingEstBound)
                    SetCursor(Cursors.SizeWE);

                else
                {
                    SetCursor(Cursors.SizeAll);
                    movingBounds = true;
                    mouseBoundsRelativePosition.X = mouse.X - level.Bounds.Left;
                    mouseBoundsRelativePosition.Y = mouse.Y - level.Bounds.Top;
                }
            }
            else if (!resizingEstBound && !resizingWestBound && !resizingNorthBound && !resizingSouthBound)
                SetCursor(Cursors.Default);
        }

        private void SetCursor(Cursor cursor)
        {
            mainWindow.GetXnaFrame().Cursor = cursor;
        }

        private void UpdateCamera(GameTime gameTime)
        {
            Vector2 mouse = GetMousePosition();

            if (action == Action.None && IsMouseMiddleJustPressed())
            {
                action = Action.MovingCamera;
                relative = (-mouse + new Vector2(renderer.Width, renderer.Height) / 2) / renderer.Zoom - renderer.Center;
            }
            else if (action == Action.MovingCamera)
            {
                if (IsMouseMiddlePressed())
                    renderer.Center = (-mouse + new Vector2(renderer.Width, renderer.Height) / 2) / renderer.Zoom - relative;

                else
                    action = Action.None;
            }
            else if (mainWindow.CameraFollowsPointer())
            {
                renderer.Center = mouse - new Vector2(renderer.Width, renderer.Height) / 2;
            }
            else
            {
                Vector2 move = new Vector2(0, 0);

                if (IsPressed(Keys.Left) && !IsPressed(Keys.Right))
                    move.X = -1;

                else if (IsPressed(Keys.Right) && !IsPressed(Keys.Left))
                    move.X = 1;

                if (IsPressed(Keys.Up) && !IsPressed(Keys.Down))
                    move.Y = -1;

                else if (IsPressed(Keys.Down) && !IsPressed(Keys.Up))
                    move.Y = 1;

                renderer.Center += move * (float)(gameTime.ElapsedGameTime.TotalMilliseconds * 1.5f);
            }

            int wheelDelta = GetMouseWheelDelta();
            if (wheelDelta != 0)
                renderer.Zoom += ((float)wheelDelta / 1000);
        }

        public override void Draw(GameTime gameTime)
        {
            renderer.BeginTextures();

            if (mainWindow.DisplayOnlyPlatforms())
            {
                if (mainWindow.DisplayParticles())
                    level.PlatformsLayer.Draw(renderer);

                else
                    level.PlatformsLayer.DrawWithoutEffects(renderer);
            }
            else
            {
                if (mainWindow.DisplayParticles())
                    level.Draw(renderer);

                else
                    level.DrawWithoutEffects(renderer);
            }

            renderer.EndTextures();

            drawTabOverlay[mainWindow.SelectedTabName](gameTime);

            if (selectedVertex != null)
            {
                renderer.BeginTextures();
                renderer.DrawTexture(vertexHandleTexture, new Vector2(selectedVertex.X, selectedVertex.Y), 0);
                renderer.EndTextures();
            }

            if (mainWindow.DisplayWorldOrigin())
            {
                renderer.BeginTextures();
                Texture2D levelCenterTexture = renderer.UtilityTextures["levelcenter"];
                renderer.DrawTexture(levelCenterTexture, Vector2.Zero, 0);
                renderer.EndTextures();
            }

            if (mainWindow.DisplayParticlesOrigin())
            {
                renderer.BeginTextures();
                Texture2D particleCenterTexture = renderer.UtilityTextures["particlecenter"];

                foreach (ParticleEffect particleEffect in currentLayer.ParticleEffects)
                    renderer.DrawTexture(particleCenterTexture, particleEffect.Position, currentLayer.Depth);

                renderer.EndTextures();
            }
        }

        private void DrawLayerOverlay(GameTime gameTime)
        {
            if (mainWindow.DisplayOverlay())
                currentLayer.DrawEditor(renderer);

            DrawBoundsOverlay(gameTime);
        }

        private void DrawBoundsOverlay(GameTime gameTime)
        {
            renderer.DrawShape(level.Bounds);
        }

        public List<string> GetLevelsDirectories()
        {
            List<string> levelsDirectories = new List<string>();
            
            DirectoryInfo levelsDir = new DirectoryInfo(content.RootDirectory + "/levels");

            DirectoryInfo[] dirs = levelsDir.GetDirectories();

            foreach (DirectoryInfo dir in dirs)
                levelsDirectories.Add(dir.Name);
            
            return levelsDirectories;
        }

        public void AddElement(string name)
        {
            Texture2D texture = content.Load<Texture2D>(name);
            texture.Name = name;
            currentLayer.AddElement(new LevelElement(texture, null, null, Vector2.Zero));
        }

        public void ToggleRemovingElementAction()
        {
            if (action != Action.RemovingElement)
                action = Action.RemovingElement;

            else
                action = Action.None;
        }

        public void ToggleElementPropertiesAction()
        {
            if (action != Action.ElementProperties)
                action = Action.ElementProperties;

            else
                action = Action.None;
        }

        public void ToggleRemovingParticleEffectAction()
        {
            if (action != Action.RemovingParticleEffect)
                action = Action.RemovingParticleEffect;

            else
                action = Action.None;
        }

        public void SaveLevel(string name)
        {
            string levelsDir = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%") + "/rofl/levels";

            if (!Directory.Exists(levelsDir))
                Directory.CreateDirectory(levelsDir);

            string file = levelsDir + "/" + name;
            LevelWriter levelWriter = new LevelWriter(level);
            File.WriteAllBytes(file, levelWriter.Write());
        }

        public void SetParticleEffect(string name)
        {
            action = Action.AddingParticleEffect;
            currentParticleEffect = ParticleEffect.Get(name);
            SetCursor(Cursors.Hand);
        }

        public void NewLevel()
        {
            level = new Level();
            LevelLayer platformsLayer = new LevelLayer(0);
            level.AddLayer(platformsLayer);
            currentLayer = platformsLayer;
            mainWindow.UpdateLayersNodes();
            mainWindow.UpdateCurrentLayerPanel();
            mainWindow.UpdateXnaFrame();
        }

        public void OpenLevel(LevelData levelData)
        {
            level = levelData.GetLevel(content);
            currentLayer = level.PlatformsLayer;
            mainWindow.UpdateLayersNodes();
            mainWindow.UpdateCurrentLayerPanel();
            mainWindow.UpdateXnaFrame();
        }
    }
}
