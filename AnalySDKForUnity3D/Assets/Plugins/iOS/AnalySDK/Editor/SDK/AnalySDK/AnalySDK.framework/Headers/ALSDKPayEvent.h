//
//  ALSDKPayEvent.h
//  AnalySDK
//
//  Created by 陈剑东 on 2018/1/25.
//  Copyright © 2018年 Mob. All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 统计支付事件对象
 */
@interface ALSDKPayEvent : NSObject 

/**
 支付价钱,单位为分
 */
@property (nonatomic) int payMoney;

/**
 消费内容类型,如月卡,道具,vip
 */
@property (nonatomic, copy) NSString *payContent;

/**
 支付方式,如支付宝,微信
 */
@property (nonatomic, copy) NSString *payType;

/**
 参与的活动
 */
@property (nonatomic, copy) NSString *payActivity;

/**
 折扣金额,建议使用double
 */
@property (nonatomic, strong) NSNumber *payDiscount;

/**
 折扣原因
 */
@property (nonatomic, copy) NSString *discountReason;

/**
 *  其他自定义属性
 */
@property (nonatomic, strong) NSDictionary *customProperties;

@end
