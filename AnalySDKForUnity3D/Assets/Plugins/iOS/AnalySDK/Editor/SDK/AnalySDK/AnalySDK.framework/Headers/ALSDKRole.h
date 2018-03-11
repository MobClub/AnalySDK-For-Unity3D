//
//  ALSDKRole.h
//  AnalySDK
//
//  Created by 陈剑东 on 2018/1/19.
//  Copyright © 2018年 Mob. All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 统计角色对象
 */
@interface ALSDKRole : NSObject

/**
 创建角色
 
 @param userId 用户id
 @param roleId 角色id
 @return 用户实体
 */
+ (ALSDKRole *)roleWithUserId:(NSString *)userId roleId:(NSString *)roleId;

/**
 用户id(必传属性)
 */
@property (nonatomic, copy) NSString *userId;

/**
 角色id(必传属性)
 */
@property (nonatomic, copy) NSString *roleId;

/**
 区服
 */
@property (nonatomic, copy) NSString *roServer;

/**
 角色名称
 */
@property (nonatomic, copy) NSString *roName;

/**
 角色职业
 */
@property (nonatomic, copy) NSString *roCareer;

/**
 角色等级
 */
@property (nonatomic, strong) NSNumber *roLevel;

/**
 角色vip级别
 */
@property (nonatomic, copy) NSString *roVip;

/**
 角色排位级别
 */
@property (nonatomic, copy) NSString *roRankLevel;

/**
 角色体力
 */
@property (nonatomic, strong) NSNumber *roEnergy;

/**
 角色货币（直充货币）
 */
@property (nonatomic, strong) NSNumber *roMoney;

/**
 角色游戏币（非直充货币）
 */
@property (nonatomic, strong) NSNumber *roCoin;

/**
 核心资源1
 */
@property (nonatomic, strong) NSNumber *roSource1;

/**
 核心资源2
 */
@property (nonatomic, strong) NSNumber *roSource2;

/**
 核心资源3
 */
@property (nonatomic, strong) NSNumber *roSource3;

/**
 核心资源4
 */
@property (nonatomic, strong) NSNumber *roSource4;

/**
 *  其他自定义属性
 */
@property (nonatomic, strong) NSDictionary *customProperties;


@end
