//
//  AnalySDK.h
//  AnalySDK
//
//  Created by 陈剑东 on 2017/5/12.
//  Copyright © 2017年 Mob. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "ALSDKUser.h"
#import "ALSDKRole.h"
#import "ALSDKPayEvent.h"

@class CLLocation;

@interface AnalySDK : NSObject

#pragma mark - 事件类型

/**
 *  事件统计(通用)
 *
 *  @param eventName 事件名称
 *  @param params    事件属性
 */
+ (void)trackEvent:(NSString *)eventName eventParams:(NSDictionary *)params;

/**
 支付事件统计(建议支付类型事件使用此接口统计)

 @param payEvent 支付事件
 */
+ (void)trackPayEvent:(ALSDKPayEvent *)payEvent;

/**
 用户注册事件
 建议使用 +[ALSDKUser userWithId:regType:regChannel:]
 创建带有注册类型(regType)和注册渠道(regChannel)的user

 @param user 用户实体
 */
+ (void)userRegist:(ALSDKUser *)user;

/**
 用户登录事件
 建议使用 +[ALSDKUser userWithId:loginType:loginChannel:]
 创建带有登录类型(regType)和登录渠道(regChannel)的user
 
 @param user 用户实体
 */
+ (void)userLogin:(ALSDKUser *)user;

/**
 用户信息更新事件
 
 @param user 用户实体
 */
+ (void)userUpdate:(ALSDKUser *)user;

/**
 角色创建事件

 @param role 角色实体
 */
+ (void)roleCreate:(ALSDKRole *)role;

/**
 角色登录事件

 @param role 角色实体
 */
+ (void)roleLogin:(ALSDKRole *)role;

/**
 角色信息更新事件

 @param role 角色实体
 */
+ (void)roleUpdate:(ALSDKRole *)role;

/**
 *  设置地理位置信息(一旦设置,则事件的追踪均带上此地理信息;否则不带)
 *
 *  @param location 地理位置
 */
+ (void)setLocation:(CLLocation *)location;

/**
 获取跟踪标识

 @param result 回调
 */
+ (void)trackId:(void (^)(NSString *trackId))result;

/**
 *  标记用户
 *
 *  @param userId 用户标识
 *  @param user   用户对象
 */
+ (void)identifyUser:(NSString *)userId userEntity:(ALSDKUser *)user __deprecated_msg("use userRegist/userLogin/userUpdate instead.");

@end
