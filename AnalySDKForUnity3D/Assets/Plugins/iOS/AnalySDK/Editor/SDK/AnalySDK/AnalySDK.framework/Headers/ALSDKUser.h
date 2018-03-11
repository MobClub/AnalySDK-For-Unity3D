//
//  ALSDKUser.h
//  AnalySDK
//
//  Created by 陈剑东 on 2017/5/24.
//  Copyright © 2017年 Mob. All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 统计用户对象
 */
@interface ALSDKUser : NSObject

/**
 创建用户

 @param userId 用户标识(必填)
 @return 用户
 */
+ (ALSDKUser *)userWithId:(NSString *)userId;

/**
 创建用户 (建议在调用 [AnalySDK userRegist:] 前使用)

 @param userId 用户标志(必填)
 @param regType 注册类型(可选)
 @param regChannel 注册频道(可选)
 @return 用户
 */
+ (ALSDKUser *)userWithId:(NSString *)userId regType:(NSString *)regType regChannel:(NSString *)regChannel;

/**
 创建用户 (建议在调用 [AnalySDK userLogin:] 前使用)

 @param userId 用户标志(必填)
 @param loginType 登录类型(可选)
 @param loginChannel 登录频道(可选)
 @return 用户
 */
+ (ALSDKUser *)userWithId:(NSString *)userId loginType:(NSString *)loginType loginChannel:(NSString *)loginChannel;

/**
 用户id(必传属性)
 */
@property (nonatomic, copy) NSString *userId;

/**
 *  昵称
 */
@property (nonatomic, copy) NSString *nickName;

/**
 *  性别
 */
@property (nonatomic, copy) NSString *gender;

/**
 *  国家
 */
@property (nonatomic, copy) NSString *country;

/**
 *  省份
 */
@property (nonatomic, copy) NSString *province;

/**
 *  城市
 */
@property (nonatomic, copy) NSString *city;

/**
 年龄
 */
@property (nonatomic, strong) NSNumber *age;

/**
 星座
 */
@property (nonatomic, copy) NSString *constellation;

/**
 生肖
 */
@property (nonatomic, copy) NSString *zodiac;

/**
 注册方式
 */
@property (nonatomic, copy) NSString *regType;

/**
 注册渠道
 */
@property (nonatomic, copy) NSString *regChannel;

/**
 登陆方式
 */
@property (nonatomic, copy) NSString *loginType;

/**
 登陆渠道
 */
@property (nonatomic, copy) NSString *loginChannel;

/**
 账号类型
 */
@property (nonatomic, copy) NSString *userType;

/**
 防沉迷标识
 */
@property (nonatomic, copy) NSString *addiction;

/**
 账号通用货币
 */
@property (nonatomic, strong) NSNumber *money;

/**
 *  其他自定义属性
 */
@property (nonatomic, strong) NSDictionary *customProperties;

/**
 *  姓名
 */
@property (nonatomic, copy) NSString *name __deprecated;

/**
 *  生日
 */
@property (nonatomic, strong) NSDate *birthday __deprecated;

/**
 *  注册渠道
 */
@property (nonatomic, copy) NSString *retistryChannel __deprecated;

/**
 *  首次访问时间
 */
@property (nonatomic, strong) NSDate *firstAccessTime __deprecated;

/**
 *  用户注册时间戳 (毫秒为单位,如1496289659821,其实际对应时间为2017/6/1 12:0:59)
 */
@property (nonatomic) NSInteger registryTime __deprecated;

@end
