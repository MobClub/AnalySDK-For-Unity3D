//
//  AnalySDKUnity3DBridge.m
//  Unity-iPhone
//
//  Created by 陈剑东 on 2018/1/16.
//

#import "AnalySDKUnity3DBridge.h"
#import <MOBFoundation/MOBFJson.h>
#import <AnalySDK/AnalySDK.h>
#import <CoreLocation/CoreLocation.h>

#if defined (__cplusplus)
extern "C" {
#endif

    extern void __iosAnalySDKtrackEvent (void *eventName, void *eventsInfo);
    
    extern void __iosAnalySDKSetLocation (float latitude, float longitude);
    
    extern void __iosAnalySDKUserRegist (void *eventsInfo);
    
    extern void __iosAnalySDKUserLogin (void *eventsInfo);
    
    extern void __iosAnalySDKUserUpdate (void *eventsInfo);
    
    extern void __iosAnalySDKRoleCreate (void *eventsInfo);
    
    extern void __iosAnalySDKRoleLogin (void *eventsInfo);
    
    extern void __iosAnalySDKRoleUpdate (void *eventsInfo);
    
    extern void __iosAnalySDKTrackPayEvent (void *eventsInfo);

    
    ALSDKUser *__parseUserHashtable (void *eventsInfo);
    ALSDKRole *__parseRoleHashtable (void *eventsInfo);
    ALSDKPayEvent *__parsePayEventHashtable (void *eventsInfo);
    
    void __iosAnalySDKtrackEvent (void *eventName, void *eventsInfo)
    {
        NSString *event = [NSString stringWithCString:eventName encoding:NSUTF8StringEncoding];
        NSString *theParamsStr = [NSString stringWithCString:eventsInfo encoding:NSUTF8StringEncoding];
        NSDictionary *eventParams = [MOBFJson objectFromJSONString:theParamsStr];
        
        [AnalySDK trackEvent:event eventParams:eventParams];
    }
    
    void __iosAnalySDKSetLocation (float latitude, float longitude)
    {
        CLLocation *location = [[CLLocation alloc] initWithLatitude:latitude longitude:longitude];
        [AnalySDK setLocation:location];
    }
    
    void __iosAnalySDKUserRegist (void *eventsInfo)
    {
        ALSDKUser *user = __parseUserHashtable(eventsInfo);
        [AnalySDK userRegist:user];
    }

    void __iosAnalySDKUserLogin (void *eventsInfo)
    {
        ALSDKUser *user = __parseUserHashtable(eventsInfo);
        [AnalySDK userLogin:user];
    }
    
    void __iosAnalySDKUserUpdate (void *eventsInfo)
    {
        ALSDKUser *user = __parseUserHashtable(eventsInfo);
        [AnalySDK userUpdate:user];
    }
    
    void __iosAnalySDKRoleCreate (void *eventsInfo)
    {
        ALSDKRole *role = __parseRoleHashtable(eventsInfo);
        [AnalySDK roleCreate:role];
    }
    
    void __iosAnalySDKRoleLogin (void *eventsInfo)
    {
        ALSDKRole *role = __parseRoleHashtable(eventsInfo);
        [AnalySDK roleLogin:role];
    }
    
    void __iosAnalySDKRoleUpdate (void *eventsInfo)
    {
        ALSDKRole *role = __parseRoleHashtable(eventsInfo);
        [AnalySDK roleUpdate:role];
    }
    
    void __iosAnalySDKTrackPayEvent (void *eventsInfo)
    {
        ALSDKPayEvent *payEvent = __parsePayEventHashtable(eventsInfo);
        [AnalySDK trackPayEvent:payEvent];
    }
    
    ALSDKUser *__parseUserHashtable (void *eventsInfo)
    {
        NSString *theParamsStr = [NSString stringWithCString:eventsInfo encoding:NSUTF8StringEncoding];
        NSDictionary *eventParams = [MOBFJson objectFromJSONString:theParamsStr];
        
        NSString *userId = eventParams[@"_userId"];
        ALSDKUser *user = [ALSDKUser userWithId:userId];
        user.nickName = eventParams[@"_nickName"];
        user.gender = eventParams[@"_gender"];
        user.country = eventParams[@"_country"];
        user.province = eventParams[@"_province"];
        user.city = eventParams[@"_city"];
        user.age = eventParams[@"_age"];
        user.constellation = eventParams[@"_constellation"];
        user.zodiac = eventParams[@"_zodiac"];
        user.regType = eventParams[@"_regType"];
        user.regChannel = eventParams[@"_regChannel"];
        user.loginType = eventParams[@"_loginType"];
        user.loginChannel = eventParams[@"_loginChannel"];
        user.userType = eventParams[@"_userType"];
        user.addiction = eventParams[@"_addiction"];
        user.addiction = eventParams[@"_addiction"];
        user.money = eventParams[@"_money"];
        
        NSString *customJsonStr = eventParams[@"customProperties"];
        if (customJsonStr.length > 0)
        {
            NSDictionary *customProperties = [MOBFJson objectFromJSONString:customJsonStr];
            user.customProperties = customProperties;
        }
        return user;
    }
    
    ALSDKRole *__parseRoleHashtable (void *eventsInfo)
    {
        NSString *theParamsStr = [NSString stringWithCString:eventsInfo encoding:NSUTF8StringEncoding];
        NSDictionary *eventParams = [MOBFJson objectFromJSONString:theParamsStr];
        
        NSString *userId = eventParams[@"_userId"];
        NSString *roleId = eventParams[@"_roleId"];
        ALSDKRole *role = [ALSDKRole roleWithUserId:userId roleId:roleId];
        
        role.roServer = eventParams[@"_roServer"];
        role.roName = eventParams[@"_roName"];
        role.roCareer = eventParams[@"_roCareer"];
        role.roLevel = eventParams[@"_roLevel"];
        role.roVip = eventParams[@"_roVip"];
        role.roRankLevel = eventParams[@"_roRankLevel"];
        role.roEnergy = eventParams[@"_roEnergy"];
        role.roMoney = eventParams[@"_roMoney"];
        role.roCoin = eventParams[@"_roCoin"];
        role.roSource1 = eventParams[@"_roSource1"];
        role.roSource2 = eventParams[@"_roSource2"];
        role.roSource3 = eventParams[@"_roSource3"];
        role.roSource4 = eventParams[@"_roSource4"];
        
        NSString *customJsonStr = eventParams[@"customProperties"];
        if (customJsonStr.length > 0)
        {
            NSDictionary *customProperties = [MOBFJson objectFromJSONString:customJsonStr];
            role.customProperties = customProperties;
        }
        return role;
    }
    
    ALSDKPayEvent *__parsePayEventHashtable (void *eventsInfo)
    {
        NSString *theParamsStr = [NSString stringWithCString:eventsInfo encoding:NSUTF8StringEncoding];
        NSDictionary *eventParams = [MOBFJson objectFromJSONString:theParamsStr];
        
        ALSDKPayEvent *payEvent = [[ALSDKPayEvent alloc] init];
        
        payEvent.payMoney = eventParams[@"_payMoney"];
        payEvent.payContent = eventParams[@"_payContent"];
        payEvent.payType = eventParams[@"_payType"];
        payEvent.payActivity = eventParams[@"_payActivity"];
        payEvent.payDiscount = eventParams[@"_payDiscount"];
        payEvent.discountReason = eventParams[@"_discountReason"];
        
        NSString *customJsonStr = eventParams[@"customProperties"];
        if (customJsonStr.length > 0)
        {
            NSDictionary *customProperties = [MOBFJson objectFromJSONString:customJsonStr];
            payEvent.customProperties = customProperties;
        }
        return payEvent;
    }

#if defined (__cplusplus)
}
#endif

@implementation AnalySDKUnity3DBridge

@end
