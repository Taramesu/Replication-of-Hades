using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PlayerInputAuthoring : MonoBehaviour
{
   public class Baker : Baker<PlayerInputAuthoring>
    {
        public override void Bake(PlayerInputAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var moveInputData = new PlayerInput.PlayerMoveInput { };
            var dashInputData = new PlayerInput.PlayerDashInput { };
            var attackInputData = new PlayerInput.PlayerAttackInput { };
            var specialInputData = new PlayerInput.PlayerSpecialInput { };
            var castInputData = new PlayerInput.PlayerCastInput { };
            var callInputData = new PlayerInput.PlayerCallInput { };
            var interactInputData = new PlayerInput.PlayerInteractInput { };
            var giftInputData = new PlayerInput.PlayerGiftInput { };
            var booninfoInputData = new PlayerInput.PlayerBooninfoInput { };
            var openCodexInputData = new PlayerInput.PlayerOpenCodexInput { };
            var summonInputData = new PlayerInput.PlayerSummonInput { };
            var reloadInputData = new PlayerInput.PlayerReloadInput { };
            var screenCaptureInpurData = new PlayerInput.PlayerScreenCaptureInput { };

            AddComponent(entity, moveInputData);
            AddComponent(entity, dashInputData);
            AddComponent(entity, attackInputData);
            AddComponent(entity, specialInputData);
            AddComponent(entity, castInputData);
            AddComponent(entity, callInputData);
            AddComponent(entity, interactInputData);
            AddComponent(entity, giftInputData);
            AddComponent(entity, booninfoInputData);
            AddComponent(entity, openCodexInputData);
            AddComponent(entity, summonInputData);
            AddComponent(entity, reloadInputData);
            AddComponent(entity, screenCaptureInpurData);
        }
    }
}
