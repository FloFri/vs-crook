using Vintagestory.API.Common;
using Vintagestory.API.Server;
using Vintagestory.API.Util;

namespace Crook
{
    public class CrookModSystem : ModSystem
    {
        ICoreAPI api;

        public override void Start(ICoreAPI api)
        {
            this.api = api;

            api.RegisterBlockBehaviorClass("CrookOnLeaves", typeof(CrookOnLeavesBehavior));
        }

        public override void StartServerSide(ICoreServerAPI api)
        {
            api.Event.ServerRunPhase(EnumServerRunPhase.GameReady, addCrookOnLeavesBehavior);
        }

        private void addCrookOnLeavesBehavior()
        {
            Block[] leaveBlocks = api.World.SearchBlocks(new AssetLocation("game", "leaves-*"));
            foreach (Block leaveBlock in leaveBlocks)
            {
                leaveBlock.BlockBehaviors = leaveBlock.BlockBehaviors.Append(new CrookOnLeavesBehavior(leaveBlock));
            }

            Block[] leaveBranchyBlocks = api.World.SearchBlocks(new AssetLocation("game", "leavesbranchy-*"));
            foreach (Block leaveBranchyBlock in leaveBranchyBlocks)
            {
                leaveBranchyBlock.BlockBehaviors = leaveBranchyBlock.BlockBehaviors.Append(new CrookOnLeavesBehavior(leaveBranchyBlock));
            }
        }
    }
}