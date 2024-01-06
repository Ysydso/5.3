import {NextRequest, NextResponse} from "next/server";
import {getToken} from "next-auth/jwt";
import {env} from "@/next.config";

export async function GET(req: NextRequest){
    const token = await getToken({ req, secret: env.NEXTAUTH_SECRET })

    console.log(token.accessToken)

    return NextResponse.json({})
}