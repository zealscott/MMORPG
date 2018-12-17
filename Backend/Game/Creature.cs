using System;
using System.Collections.Generic;
using Common;
using GeometRi;

namespace Backend.Game
{
    public class Creature : Entity
    {
        public int currentHP;
        public int maxHP;
        public int level;
        public int speed;
        public int attack;
        public int defense;
        public int intelligence;
        public int GoldNum;
        public int SilverNum;
        public float invulnerableTime;
        public float hitAngle;
        public bool dead = false;
        public bool aggressive = false;
        public string scene;

        protected DateTime m_lastHitTS = DateTime.UnixEpoch;

        public bool IsInvulnerable()
        {
            return invulnerableTime * 1000 > (DateTime.Now - m_lastHitTS).TotalMilliseconds;
        }

        public void FindPath(Entity target, LinkedList<Point3d> steps)
        {
            GetScene().FindPath(Position, target.Position, steps);
        }

        public bool FindPath(Point3d target, LinkedList<Point3d> steps)
        {
            return GetScene().FindPath(Position, target, steps);
        }

        // the enemy is null if not exists one
        virtual public void OnAttack(Creature enemy = null)
        {
            if (currentHP == 0)
                return;

            int targetId = 0;
            if (enemy != null)
            {
                if (enemy.currentHP == 0)
                    return;
                if (enemy.IsInvulnerable())
                    return;
                targetId = enemy.entityId;
            }
            SAttack attack = new SAttack();
            attack.ID = this.entityId;
            attack.targetID = targetId;
            Broadcast(attack);
        }


        // the enemy is null if not exists one
        virtual public void OnHit(Creature enemy, int hpDec)
        {
        }

        virtual public void OnDie()
        {

        }

        virtual public void OnReSpawn()
        {

        }

        override public DEntity ToDEntity()
        {
            DEntity entity = base.ToDEntity();
            entity.currentHP = currentHP;
            entity.maxHP = maxHP;
            entity.level = level;
            entity.speed = speed;
            entity.attack = attack;
            entity.defense = defense;
            entity.intelligence = intelligence;
            entity.SilverNum = SilverNum;
            entity.GoldNum = GoldNum;
            return entity;
        }

        override public void FromDEntity(DEntity entity)
        {
            currentHP = entity.currentHP;
            maxHP = entity.maxHP;
            level = entity.level;
            speed = entity.speed;
            aggressive = entity.aggressive;
            invulnerableTime = entity.invTime;
            hitAngle = entity.hitAngle;
            attack = entity.attack;
            defense = entity.defense;
            intelligence = entity.intelligence;
            GoldNum = entity.GoldNum;
            SilverNum = entity.SilverNum;
            base.FromDEntity(entity);
        }
    }
}
