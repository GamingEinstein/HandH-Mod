using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Projectiles.Bosses
{
    public class Hev : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slayer Beam!");
        }

        public override void SetDefaults()
        {
            projectile.damage = 500;
            projectile.width = 18;
            projectile.height = 42;
            projectile.aiStyle = 1;
            aiType = ProjectileID.Bullet;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 500;
            projectile.tileCollide = false;
            projectile.hostile = true;
            projectile.scale = 1.2f;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void AI()
        {
            projectile.velocity.Y += projectile.ai[0];
        }

    }
}