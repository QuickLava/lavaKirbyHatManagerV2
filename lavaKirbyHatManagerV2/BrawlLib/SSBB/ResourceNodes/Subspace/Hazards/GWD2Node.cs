using BrawlLib.Internal;
using BrawlLib.SSBB.Types.Subspace.Hazards;
using System;
using System.ComponentModel;

namespace BrawlLib.SSBB.ResourceNodes
{
    public class GWD2Node : BLOCEntryNode
    {
        public override Type SubEntryType => typeof(GWD2EntryNode);
        protected override string baseName => "Secondary Winds";

        internal static ResourceNode TryParse(DataSource source, ResourceNode parent)
        {
            return source.Tag == "GWD2" ? new GWD2Node() : null;
        }
    }

    public unsafe class GWD2EntryNode : ResourceNode
    {
        protected internal GWD2Entry Data;

        [DisplayName("Unknown0x00 (uint)")]
        [Category("Unknown")]
        public uint Unknown0x00
        {
            get => Data._unknown0x00;
            set
            {
                Data._unknown0x00 = value;
                SignalPropertyChange();
            }
        }

        [DisplayName("Unknown0x04 (uint)")]
        [Category("Unknown")]
        public uint Unknown0x04
        {
            get => Data._unknown0x04;
            set
            {
                Data._unknown0x04 = value;
                SignalPropertyChange();
            }
        }

        [DisplayName("Unknown0x08 (uint)")]
        [Category("Unknown")]
        public uint Unknown0x08
        {
            get => Data._unknown0x08;
            set
            {
                Data._unknown0x08 = value;
                SignalPropertyChange();
            }
        }

        [DisplayName("Unknown0x0C (uint)")]
        [Category("Unknown")]
        public uint Unknown0x0C
        {
            get => Data._unknown0x0C;
            set
            {
                Data._unknown0x0C = value;
                SignalPropertyChange();
            }
        }

        [DisplayName("Unknown0x10 (uint)")]
        [Category("Unknown")]
        public uint Unknown0x10
        {
            get => Data._unknown0x10;
            set
            {
                Data._unknown0x10 = value;
                SignalPropertyChange();
            }
        }

        [DisplayName("Unknown0x14 (uint)")]
        [Category("Unknown")]
        public uint Unknown0x14
        {
            get => Data._unknown0x14;
            set
            {
                Data._unknown0x14 = value;
                SignalPropertyChange();
            }
        }

        [DisplayName("Unknown0x18 (uint)")]
        [Category("Unknown")]
        public uint Unknown0x18
        {
            get => Data._unknown0x18;
            set
            {
                Data._unknown0x18 = value;
                SignalPropertyChange();
            }
        }

        [DisplayName("Unknown0x1C (uint)")]
        [Category("Unknown")]
        public uint Unknown0x1C
        {
            get => Data._unknown0x1C;
            set
            {
                Data._unknown0x1C = value;
                SignalPropertyChange();
            }
        }

        [DisplayName("Unknown0x20 (uint)")]
        [Category("Unknown")]
        public uint Unknown0x20
        {
            get => Data._unknown0x20;
            set
            {
                Data._unknown0x20 = value;
                SignalPropertyChange();
            }
        }

        [DisplayName("Unknown0x24 (uint)")]
        [Category("Unknown")]
        public uint Unknown0x24
        {
            get => Data._unknown0x24;
            set
            {
                Data._unknown0x24 = value;
                SignalPropertyChange();
            }
        }

        [DisplayName("Unknown0x28 (uint)")]
        [Category("Unknown")]
        public uint Unknown0x28
        {
            get => Data._unknown0x28;
            set
            {
                Data._unknown0x28 = value;
                SignalPropertyChange();
            }
        }

        [DisplayName("Unknown0x2C (uint)")]
        [Category("Unknown")]
        public uint Unknown0x2C
        {
            get => Data._unknown0x2C;
            set
            {
                Data._unknown0x2C = value;
                SignalPropertyChange();
            }
        }

        [DisplayName("Unknown0x30 (uint)")]
        [Category("Unknown")]
        public uint Unknown0x30
        {
            get => Data._unknown0x30;
            set
            {
                Data._unknown0x30 = value;
                SignalPropertyChange();
            }
        }

        [DisplayName("Unknown0x34 (float)")]
        [Category("Unknown")]
        public float Unknown0x34
        {
            get => Data._unknown0x34;
            set
            {
                Data._unknown0x34 = value;
                SignalPropertyChange();
            }
        }

        [DisplayName("Unknown0x38 (float)")]
        [Category("Unknown")]
        public float Unknown0x38
        {
            get => Data._unknown0x38;
            set
            {
                Data._unknown0x38 = value;
                SignalPropertyChange();
            }
        }

        [DisplayName("Unknown0x3C (float)")]
        [Category("Unknown")]
        public float Unknown0x3C
        {
            get => Data._unknown0x3C;
            set
            {
                Data._unknown0x3C = value;
                SignalPropertyChange();
            }
        }

        [DisplayName("Unknown0x40 (float)")]
        [Category("Unknown")]
        public float Unknown0x40
        {
            get => Data._unknown0x40;
            set
            {
                Data._unknown0x40 = value;
                SignalPropertyChange();
            }
        }

        [DisplayName("Unknown0x44 (uint)")]
        [Category("Unknown")]
        public uint Unknown0x44
        {
            get => Data._unknown0x44;
            set
            {
                Data._unknown0x44 = value;
                SignalPropertyChange();
            }
        }

        [DisplayName("Unknown0x48 (uint)")]
        [Category("Unknown")]
        public uint Unknown0x48
        {
            get => Data._unknown0x48;
            set
            {
                Data._unknown0x48 = value;
                SignalPropertyChange();
            }
        }

        public override int OnCalculateSize(bool force)
        {
            return GWD2Entry.Size;
        }

        public override bool OnInitialize()
        {
            Data = *(GWD2Entry*) WorkingUncompressed.Address;

            if (_name == null)
            {
                _name = $"Wind [{Index}]";
            }

            return base.OnInitialize();
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            GWD2Entry* hdr = (GWD2Entry*)address;
            *hdr = Data;
        }
    }
}