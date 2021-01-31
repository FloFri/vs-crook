using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

namespace Crook
{
    public class CrookOnLeavesBehavior : BlockBehavior
    {
        public CrookOnLeavesBehavior(Block block) : base(block)
        {
        }

        public override void OnBlockBroken(IWorldAccessor world, BlockPos pos, IPlayer byPlayer, ref EnumHandling handling)
        {
            if (byPlayer.InventoryManager.ActiveHotbarSlot == null ||
                byPlayer.InventoryManager.ActiveHotbarSlot.Itemstack == null ||
                byPlayer.InventoryManager.ActiveHotbarSlot.Itemstack.Item == null ||
                !byPlayer.InventoryManager.ActiveHotbarSlot.Itemstack.Item.Code.Equals(new AssetLocation("crook", "crook")))
            {
                return;
            }

            if (world.Rand.Next(4) != 0) 
            {
                return; 
            }

            var woodType = this.block.FirstCodePart(2);
            var sapplingBlock = world.GetBlock(new AssetLocation("game", $"sapling-{woodType}-free"));

            world.SpawnItemEntity(new ItemStack(sapplingBlock), new Vec3d(pos.X + 0.5, pos.Y + 0.5, pos.Z + 0.5), null);
        }
    }
}
