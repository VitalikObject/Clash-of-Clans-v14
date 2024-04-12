using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class Skins : Data
    {
        public Skins(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string Character { get; set; }

        public bool IsDefaultSkin { get; set; }

        public bool EnabledByCalendar { get; set; }

        public int PurchasePrice { get; set; }

        public string PurchaseUnlock { get; set; }

        public string TID { get; set; }

        public string Icon { get; set; }

        public string Geometry { get; set; }

        public string Texture { get; set; }

        public string NormalMap { get; set; }

        public string MaterialMap { get; set; }

        public string EmissionMap { get; set; }

        public string OpacityMap { get; set; }

        public string Animation { get; set; }

        public string AltAnimation { get; set; }

        public int CameraDistance { get; set; }

        public int ViewportWidth { get; set; }

        public int ViewportHeight { get; set; }

        public string CelebrateSfx { get; set; }

        public int CelebrateSfxVolume { get; set; }

        public string DeployEffect { get; set; }

        public string AttackEffect { get; set; }

        public string AttackEffect2 { get; set; }

        public string AttackEffectAlt { get; set; }

        public string AttackEffect2Alt { get; set; }

        public string HitEffect { get; set; }

        public string DieEffect { get; set; }

        public string AbilityTriggerEffect { get; set; }

        public string SkinChangeEffect { get; set; }

        public string ParticleEffect3D { get; set; }

        public string GunBone { get; set; }

        public string ProjectileVis { get; set; }

        public string RageProjectileVis { get; set; }

        public string AbilityProjectileVis { get; set; }

        public string SpawnedTroopAnimation { get; set; }

        public string Environment { get; set; }

        public string MakeCreator { get; set; }

        public int ShadowScale { get; set; }

        public string Tier { get; set; }

        public string ThemeIcon { get; set; }

        public string ThemeTID { get; set; }

        public bool FeatureCustomModel { get; set; }

        public bool FeatureCustomTextures { get; set; }

        public bool FeatureCustomAnimations { get; set; }

        public bool FeatureCustomEffects { get; set; }

        public bool FeatureCustomSounds { get; set; }

        public bool FeatureCustomVoiceovers { get; set; }

        public bool FeatureCustomUnits { get; set; }

        public bool FeatureExtraAnimations { get; set; }

        public bool FeatureExtraEffects { get; set; }

        public bool FeatureExtraSounds { get; set; }
    }
}
