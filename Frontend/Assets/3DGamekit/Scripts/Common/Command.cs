/*
 * message code define
 * if you are changing this file, mind to rebuild both Frontend and Backend later
 */

namespace Common
{
    public enum Command
    {
        NONE,
        SBEGIN = 0,
        S_PLAYER_ENTER,
        S_ITEM_SPAWN,
        S_SPAWN,
        S_PLAYER_RESPAWN,
        S_PLAYER_ACTION,
        S_ENTITY_DESTROY,
        S_PLAYER_MOVE,
        S_SPRITE_MOVE,
        S_JUMP,
        S_ATTACK,
        S_EQUIP_WEAPON,
        S_HIT,
        S_TAKE_ITEM,
        S_EXIT,
        S_SPRITE_DIE,
        S_PLAYER_DIE,
        S_TIP_INFO,
        // ADD
        S_PLAYER_ATTRIBUTE,
        S_FIND_FRIENDS,
        S_CHAT_MESSAGE,
        S_TREASURE_ATTRIBUTE,
        S_MALL,
        S_PACKAGE,
        S_BUY_GOLD_RESULT,
        S_SEND_TO_SELLER,
        S_GETCHATHISTORY,
        SEND,
        

        CBEGIN,
        C_LOGIN,
        C_REGISTER,
        C_PLAYER_ENTER,
        C_PLAYER_ATTACK,
        C_PLAYER_JUMP,
        C_PLAYER_MOVE,
        C_PLAYER_TAKE,
        C_POSITION_REVISE,
        C_ENEMY_CLOSING,
        C_DAMAGE,
        // ADD
        C_CHAT_MESSAGE,
        C_BUY,
        C_PLAYER_ATTRIBUTE,
        C_TREASURE_WEAR,
        C_SELL_GOLD,
        C_SELL_SILVER,
        C_MALL,
        C_GETCHATHISTORY,
        C_NOT_SELL,
        CEND,
        

        DEBUGGING, // THE FOLLOWING MESSEGES ARE FOR DEBUGGING
        C_FIND_PATH,
        S_FIND_PATH,

        CMD_END, // DO NOT GREATER THAN UINT_MAX !!!
    }
}
