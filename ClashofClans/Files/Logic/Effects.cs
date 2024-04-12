using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class Effects : Data
    {
        public Effects(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string SWF { get; set; }

        public string ExportName { get; set; }

        public string ParticleEmitter { get; set; }

        public string AltParticleEmitter { get; set; }

        public int EmitterDelayMs { get; set; }

        public string IsoLayer { get; set; }

        public int CameraShake { get; set; }

        public int CameraShakeTimeMS { get; set; }

        public bool CameraShakeInReplay { get; set; }

        public bool AttachToParent { get; set; }

        public bool OrientToParent { get; set; }

        public bool SortInFrontOfParent { get; set; }

        public bool DestroyWhenParentDies { get; set; }

        public bool DetachAfterStart { get; set; }

        public bool Targeted { get; set; }

        public bool Looping { get; set; }

        public bool Beam { get; set; }

        public int MaxCount { get; set; }

        public int MinLifeTime { get; set; }

        public string Sound { get; set; }

        public int Volume { get; set; }

        public int MinPitch { get; set; }

        public int MaxPitch { get; set; }

        public string LowEndSound { get; set; }

        public int LowEndVolume { get; set; }

        public int LowEndMinPitch { get; set; }

        public int LowEndMaxPitch { get; set; }

        public int SoundDelay { get; set; }

        public bool StopSound { get; set; }

        public int PitchIncrease { get; set; }

        public bool OffsetFromGunBone { get; set; }

        public string AttachLocator { get; set; }

        public int OffsetX { get; set; }

        public int OffsetY { get; set; }

        public int OffsetZ { get; set; }

        public int Scale { get; set; }

        public int LifeTimeScale { get; set; }
    }
}
